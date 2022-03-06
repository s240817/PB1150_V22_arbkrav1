using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Ports;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Globalization;

namespace PB1150_V22_arbkrav1
{
    public partial class FormMain : Form
    {
        string appVersion = "v1";

        string defaultConfig = "DefaultTag;0.0;500.0;50;450";

        string[] instrumentConfigs;

        List<int> analogReading = new List<int>();
        List<double> analogScaledReading = new List<double>();
        List<DateTime> timeStamp = new List<DateTime>();

        enum Status
        {
            Disconnected,
            Nominal,
            Fail,
            AlarmLow,
            AlarmHigh
        }

        Status status;
        bool blinkState = true;
        bool pollState = true;

        RadioButton selectedrb;

        public FormMain()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = "[DISCONNECTED]";
            instrumentConfigs = defaultConfig.Split(';');
            bitRateSelect.SelectedItem = "9600";
            var ports = System.IO.Ports.SerialPort.GetPortNames();
            foreach (String port in ports)
            {
                comPortSelect.Items.Add(port);
            }
            if (comPortSelect.Items.Count > 0)
            {
                comPortSelect.SelectedIndex = comPortSelect.Items.Count - 1;
            }

            serialPort.DataReceived += new SerialDataReceivedEventHandler(dataReceivedHandler);
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (comPortSelect.SelectedIndex <= -1)
            {
                MessageBox.Show("No com port selected.");
                return;
            }
            if (bitRateSelect.SelectedIndex <= -1)
            {
                MessageBox.Show("No bit rate selected.");
                return;
            }

            serialPort.PortName = comPortSelect.Items[comPortSelect.SelectedIndex].ToString();
            serialPort.BaudRate = Convert.ToInt32(bitRateSelect.Items[bitRateSelect.SelectedIndex]);
            serialPort.Open();
            toolStripStatusLabel1.Text = "[CONNECTED]";

            // request instrument status
            writeSerial("readstatus");
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            serialPort.Close();
            setStatus(Status.Disconnected);

            labelLiveRecordedData.Invoke((MethodInvoker)delegate
            { labelLiveRecordedData.Text = "RECORDED"; });

            labelCurrentValue.Visible = false;
        }

        private void receiveButton_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                // FIXME is there any point to this?
                var data = serialPort.ReadExisting();
                receivedDataTextBox.AppendText(data);
            }
            else
            {
                MessageBox.Show("The serial port is not open!");
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            writeSerial(sendDataTextBox.Text);
        }

        private void buttonReadConfig_Click(object sender, EventArgs e)
        {
            // read configuration from instrument
            writeSerial("readconf");
        }

        private bool verifyConfigFields()
        {
            instrumentConfigs[0] = textBoxTagname.Text;
            instrumentConfigs[1] = textBoxLRV.Text;
            instrumentConfigs[2] = textBoxURV.Text;
            instrumentConfigs[3] = textBoxAL.Text;
            instrumentConfigs[4] = textBoxAH.Text;

            bool allGood = true;
            foreach (var config in instrumentConfigs)
            {
                if (config.Length <= 0)
                {
                    allGood = false;
                    break;
                }
            }

            return allGood;
        }

        private void buttonWriteConfig_Click(object sender, EventArgs e)
        {
            if (!verifyConfigFields())
            {
                MessageBox.Show("One or more config fields are empty. Please fill them then try again.");
                return;
            }

            Form frm = new PasswordEntryForm(this);
            frm.ShowDialog();
        }

        public void finishConfigWrite(string pw)
        {
            writeSerial(string.Format("writeconf>{0}>{1}", pw, string.Join(";", instrumentConfigs)));
        }

        private void buttonLoadConfig_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Instrument configuration|*.ssc";
            openFileDialog.Title = "Save Instrument Configuration";
            openFileDialog.FileName = "config.ssc";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the path of specified file
                string fileName = openFileDialog.FileName;
                StreamReader inputFile = new StreamReader(@fileName);
                
                string inputFileRead = inputFile.ReadLine();
                inputFile.Close();
                string[] splitElements = inputFileRead.Split('>', ';');
                string version = splitElements[0];


                textBoxTagname.Invoke((MethodInvoker)delegate
                { textBoxTagname.Text = splitElements[1]; });
                textBoxLRV.Invoke((MethodInvoker)delegate
                { textBoxLRV.Text = splitElements[2]; });
                textBoxURV.Invoke((MethodInvoker)delegate
                { textBoxURV.Text = splitElements[3]; });
                textBoxAL.Invoke((MethodInvoker)delegate
                { textBoxAL.Text = splitElements[4]; });
                textBoxAH.Invoke((MethodInvoker)delegate
                { textBoxAH.Text = splitElements[5]; });

                instrumentConfigs[0] = textBoxTagname.Text;
                instrumentConfigs[1] = textBoxLRV.Text;
                instrumentConfigs[2] = textBoxURV.Text;
                instrumentConfigs[3] = textBoxAL.Text;
                instrumentConfigs[4] = textBoxAH.Text;

                showTemporaryLabelText("Instrument configuration file loaded successfully.", 5000);
            }
        }

        private void buttonSaveConfig_Click(object sender, EventArgs e)
        {
            if (!verifyConfigFields())
            {
                MessageBox.Show("One or more config fields are empty. Please fill them then try again.");
                return;
            }

            // Source: https://stackoverflow.com/a/21472020
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Instrument configuration|*.ssc";
            saveFileDialog.Title = "Save Instrument Configuration";
            saveFileDialog.FileName = "config.ssc";

            DialogResult result = saveFileDialog.ShowDialog();
            saveFileDialog.RestoreDirectory = true;

            if (result == DialogResult.OK && saveFileDialog.FileName != "")
            {
                try
                {
                    if (saveFileDialog.CheckPathExists)
                    {
                        StreamWriter outputFile = new StreamWriter(@saveFileDialog.FileName);
                        outputFile.WriteLine(string.Format("{0}>{1}", appVersion, string.Join(";", instrumentConfigs)));
                        outputFile.Close();
                    }
                    else
                    {
                        MessageBox.Show("Given Path does not exist");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                showTemporaryLabelText("Instrument configuration file saved successfully.", 5000);
            }
        }

        void dataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            string receivedData = ((SerialPort)sender).ReadLine();
            receivedDataTextBox.Invoke((MethodInvoker)delegate
               { receivedDataTextBox.AppendText("Received: " + receivedData + "\r\n"); });

            var results = receivedData.Split(';');

            bool success;

            switch (results[0])
            {
                case "readconf":
                    textBoxTagname.Invoke((MethodInvoker)delegate
                    { textBoxTagname.Text = results[1]; });
                    textBoxLRV.Invoke((MethodInvoker)delegate
                    { textBoxLRV.Text = results[2]; });
                    textBoxURV.Invoke((MethodInvoker)delegate
                    { textBoxURV.Text = results[3]; });
                    textBoxAL.Invoke((MethodInvoker)delegate
                    { textBoxAL.Text = results[4]; });
                    textBoxAH.Invoke((MethodInvoker)delegate
                    { textBoxAH.Text = results[5]; });

                    showTemporaryLabelText("Instrument configuration read successfully.", 5000);
                    break;
                case "writeconf":
                    switch (int.Parse(results[1]))
                    {
                        case 1:
                            // success
                            showTemporaryLabelText("Instrument configuration written successfully.", 5000);
                            break;
                        default:
                            // failure
                            showTemporaryLabelText("FAILED to write instrument configuration!\r\nDid you input the correct password?", 5000);
                            break;
                    }
                    break;
                case "readraw":
                    int rawValue;
                    success = int.TryParse(results[1], out rawValue);
                    if (!success)
                    {
                        // TODO report failure
                        return;
                    }
                    // display data
                    analogReading.Add(rawValue);
                    timeStamp.Add(DateTime.Now);
                    chart1.Invoke((MethodInvoker)delegate {
                        chart1.Series["Vba"].Points.DataBindXY(timeStamp, analogReading);
                        chart1.Invalidate();
                    });

                    labelCurrentValue.Invoke((MethodInvoker)delegate {
                        labelCurrentValue.Text = String.Format("Current value: {0}", rawValue);
                    });

                    break;
                case "readscaled":
                    double scaledValue;
                    success = double.TryParse(results[1], NumberStyles.Float, CultureInfo.InvariantCulture, out scaledValue);
                    if (!success)
                    {
                        // TODO report failure
                        return;
                    }
                    // display data
                    analogScaledReading.Add(scaledValue);
                    timeStamp.Add(DateTime.Now);
                    chart1.Invoke((MethodInvoker)delegate {
                        chart1.Series["Vba"].Points.DataBindXY(timeStamp, analogScaledReading);
                        chart1.Invalidate();
                    });

                    labelCurrentValue.Invoke((MethodInvoker)delegate {
                        labelCurrentValue.Text = String.Format("Current value: {0}", scaledValue);
                    });
                    break;
                case "readstatus":
                    switch (int.Parse(results[1]))
                    {
                        case 1:
                            setStatus(Status.Fail);
                            break;
                        case 2:
                            setStatus(Status.AlarmLow);
                            break;
                        case 3:
                            setStatus(Status.AlarmHigh);
                            break;
                        default:
                            setStatus(Status.Nominal);
                            break;
                    }
                    break;
                default:
                    receivedDataTextBox.Invoke((MethodInvoker)delegate
                    { receivedDataTextBox.AppendText("Unknown command: " + results[0] + "\r\n"); });
                    break;
            }
        }

        private void autoReadButton_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                buttonLoadData.Enabled = false;

                sendDataTextBox.Invoke((MethodInvoker)delegate
                { sendDataTextBox.Text = ""; });

                labelLiveRecordedData.Invoke((MethodInvoker)delegate
                { labelLiveRecordedData.Text = "LIVE"; });
                labelLiveRecordedData.Visible = true;
                
                labelCurrentValue.Invoke((MethodInvoker)delegate
                { labelCurrentValue.Text = ""; });
                labelCurrentValue.Visible = true;

                sendDataTextBox.ReadOnly = true;
                timerDataRead.Start();
                timerBlink.Start();
                blinkState = false;

                // request data
                if (selectedrb == radioDisplayScaled)
                {
                    writeSerial("readscaled");
                }
                else
                {
                    writeSerial("readraw");
                }

                chart1.Invoke((MethodInvoker)delegate
                {
                    chart1.Titles.Clear();
                    chart1.Titles.Add("Instrument data (live)");
                });
            }
            else
            {
                MessageBox.Show("The serial port is not open!");
            }
        }

        private void manualReadButton_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                buttonLoadData.Enabled = true;

                sendDataTextBox.ReadOnly = false;

                labelLiveRecordedData.Invoke((MethodInvoker)delegate
                { labelLiveRecordedData.Text = "RECORDED"; });
                labelLiveRecordedData.Visible = true;

                labelCurrentValue.Visible = false;

                timerDataRead.Stop();
                timerBlink.Stop();
                blinkState = true;
                setStatus(status); // update image

                chart1.Invoke((MethodInvoker)delegate
                {
                    chart1.Titles.Clear();
                    chart1.Titles.Add("Instrument data");
                });

                buttonSaveCSV.Enabled = true;
                buttonSaveImage.Enabled = true;
            }
            else
            {
                MessageBox.Show("The serial port is not open!");
            }
        }

        private void timerBlink_Tick(object sender, EventArgs e)
        {
            blinkState = !blinkState;
            setStatus(status);
        }

        private void setStatus(Status s)
        {
            status = s;
            switch (status)
            {
                case Status.AlarmLow:
                    toolStripStatusLabel1.Text = "[CONNECTED] ALARM LOW!";
                    if (blinkState)
                    {
                        pictureBoxStatus.ImageLocation = "../../light_yellow.png";
                    }
                    else
                    {
                        pictureBoxStatus.ImageLocation = "../../light_off.png";
                    }
                    break;
                case Status.AlarmHigh:
                    toolStripStatusLabel1.Text = "[CONNECTED] ALARM HIGH!";
                    if (blinkState)
                    {
                        pictureBoxStatus.ImageLocation = "../../light_yellow.png";
                    }
                    else
                    {
                        pictureBoxStatus.ImageLocation = "../../light_off.png";
                    }
                    break;
                case Status.Nominal:
                    toolStripStatusLabel1.Text = "[CONNECTED]";
                    if (blinkState)
                    {
                        pictureBoxStatus.ImageLocation = "../../light_green.png";
                    }
                    else
                    {
                        pictureBoxStatus.ImageLocation = "../../light_off.png";
                    }
                    break;
                case Status.Fail:
                    toolStripStatusLabel1.Text = "[CONNECTED] FAIL!";
                    if (blinkState)
                    {
                        pictureBoxStatus.ImageLocation = "../../light_red.png";
                    }
                    else
                    {
                        pictureBoxStatus.ImageLocation = "../../light_off.png";
                    }
                    break;
                default:
                    toolStripStatusLabel1.Text = "[DISCONNECTED]";
                    pictureBoxStatus.ImageLocation = "../../light_off.png";
                    break;
            }
        }

        private void timerDataRead_Tick(object sender, EventArgs e)
        {
            pollState = !pollState;
            if (pollState)
            {
                // request data
                if (selectedrb == radioDisplayScaled)
                {
                    writeSerial("readscaled");
                }
                else
                {
                    writeSerial("readraw");
                }
            }
            else
            {
                // request state
                writeSerial("readstatus");
                
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            textBoxTagname.Invoke((MethodInvoker)delegate
            { textBoxTagname.Text = instrumentConfigs[0]; });
            textBoxLRV.Invoke((MethodInvoker)delegate
            { textBoxLRV.Text = instrumentConfigs[1]; });
            textBoxURV.Invoke((MethodInvoker)delegate
            { textBoxURV.Text = instrumentConfigs[2]; });
            textBoxAL.Invoke((MethodInvoker)delegate
            { textBoxAL.Text = instrumentConfigs[3]; });
            textBoxAH.Invoke((MethodInvoker)delegate
            { textBoxAH.Text = instrumentConfigs[4]; });

            selectedrb = radioDisplayScaled;

            chart1.Invoke((MethodInvoker)delegate
            {
                chart1.Series[0].XValueType = ChartValueType.DateTime;
                chart1.Titles.Add("Instrument data");
                ChartArea c = chart1.ChartAreas[0];
                c.AxisX.Title = "Timestamp";
                c.AxisX.LabelStyle.Format = "HH:mm:ss";
                c.AxisY.Title = "Value (scaled)";
            });
        }

        private void radioDisplay_CheckedChanged(object sender, EventArgs e)
        {
            // Source: https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.radiobutton?view=windowsdesktop-6.0
            RadioButton rb = sender as RadioButton;
            
            if (rb == null)
            {
                MessageBox.Show("Sender is not a RadioButton");
                return;
            }

            selectedrb = rb;

            // clear chart
            timeStamp.Clear();
            analogReading.Clear();
            analogScaledReading.Clear();

            chart1.Invoke((MethodInvoker)delegate
            {
                if (selectedrb == radioDisplayScaled)
                {
                    chart1.Series["Vba"].Points.DataBindXY(timeStamp, analogScaledReading);
                    chart1.ChartAreas[0].AxisY.Title = "Value (scaled)";
                }
                else
                {
                    chart1.Series["Vba"].Points.DataBindXY(timeStamp, analogReading);
                    chart1.ChartAreas[0].AxisY.Title = "Value (raw)";
                }
                chart1.Invalidate();
            });
        }

        private void writeSerial(string data)
        {
            if (!serialPort.IsOpen)
            {
                MessageBox.Show("The serial port is not open!");
                return;
            }
            serialPort.WriteLine(data);
            receivedDataTextBox.Invoke((MethodInvoker)delegate
            { receivedDataTextBox.AppendText("Sent: " + data + "\r\n"); });
        }

        private async void showTemporaryLabelText(string text, int duration_ms)
        {
            labelConfigStatus.Invoke((MethodInvoker)delegate
            {
                labelConfigStatus.Text = text;
                labelConfigStatus.Visible = true;
            });
            await Task.Delay(duration_ms);
            labelConfigStatus.Invoke((MethodInvoker)delegate
            { labelConfigStatus.Visible = false; });
        }

        private void buttonSaveImage_Click(object sender, EventArgs e)
        {
            // Source: https://stackoverflow.com/a/21472020
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG image|*.png|JPEG image|*.jpg";
            saveFileDialog.Title = "Save Chart As Image File";
            saveFileDialog.FileName = "Sample.png";

            DialogResult result = saveFileDialog.ShowDialog();
            saveFileDialog.RestoreDirectory = true;

            if (result == DialogResult.OK && saveFileDialog.FileName != "")
            {
                try
                {
                    if (saveFileDialog.CheckPathExists)
                    {
                        if (saveFileDialog.FilterIndex == 2)
                        {
                            chart1.SaveImage(saveFileDialog.FileName, ChartImageFormat.Jpeg);
                        }
                        else if (saveFileDialog.FilterIndex == 1)
                        {
                            chart1.SaveImage(saveFileDialog.FileName, ChartImageFormat.Png);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Given Path does not exist");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void buttonSaveCSV_Click(object sender, EventArgs e)
        {
            // Source: https://stackoverflow.com/a/21472020
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Comma-Separated Values file|*.csv";
            saveFileDialog.Title = "Save Instrument Data";
            saveFileDialog.FileName = "data.csv";

            DialogResult result = saveFileDialog.ShowDialog();
            saveFileDialog.RestoreDirectory = true;

            if (result == DialogResult.OK && saveFileDialog.FileName != "")
            {
                try
                {
                    if (saveFileDialog.CheckPathExists)
                    {
                        StreamWriter outputFile = new StreamWriter(@saveFileDialog.FileName);
                        if (selectedrb == radioDisplayScaled)
                        {
                            outputFile.Write("timeStamp,analogScaledReading;");
                            for (int i = 0; i < timeStamp.Count; i++)
                            {
                                outputFile.Write(string.Format("{0},{1};", timeStamp[i], analogScaledReading[i]), CultureInfo.InvariantCulture);
                            }
                        }
                        else
                        {
                            outputFile.WriteLine("timeStamp,analogReading");
                            for (int i = 0; i < timeStamp.Count; i++)
                            {
                                outputFile.Write(string.Format("{0},{1};", timeStamp[i], analogReading[i]), CultureInfo.InvariantCulture);
                            }
                        }
                        outputFile.Close();
                    }
                    else
                    {
                        MessageBox.Show("Given Path does not exist");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                showTemporaryLabelText("Instrument data record saved successfully.", 5000);
            }
        }

        private void buttonLoadData_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Comma-Separated Values file|*.csv";
            openFileDialog.Title = "Load Instrument Data";
            openFileDialog.FileName = "data.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the path of specified file
                string fileName = openFileDialog.FileName;
                StreamReader inputFile = new StreamReader(@fileName);

                string inputFileRead = inputFile.ReadToEnd();
                inputFile.Close();
                string[] lines = inputFileRead.Split(';');
                string[] conf = lines[0].Split(',');
                switch (conf[1])
                {
                    case "analogReading":
                        // raw data
                        for (int i = 1; i < lines.Length-1; i++)
                        {
                            string[] splitElements = lines[i].Split(',');
                            timeStamp.Add(DateTime.Parse(splitElements[0]));
                            analogReading.Add(int.Parse(splitElements[1]));
                        }
                        chart1.Invoke((MethodInvoker)delegate {
                            chart1.Series["Vba"].Points.DataBindXY(timeStamp, analogReading);
                            chart1.ChartAreas[0].AxisY.Title = "Value (raw)";
                            chart1.Invalidate();
                        });
                        break;
                    default:
                        // scaled data
                        for (int i = 1; i < lines.Length-1; i++)
                        {
                            string[] splitElements = lines[i].Split(',');
                            timeStamp.Add(DateTime.Parse(splitElements[0]));
                            analogScaledReading.Add(double.Parse(splitElements[1], CultureInfo.InvariantCulture));
                        }
                        chart1.Invoke((MethodInvoker)delegate {
                            chart1.Series["Vba"].Points.DataBindXY(timeStamp, analogScaledReading);
                            chart1.ChartAreas[0].AxisY.Title = "Value (scaled)";
                            chart1.Invalidate();
                        });
                        break;
                }

                labelLiveRecordedData.Invoke((MethodInvoker)delegate
                {
                    labelLiveRecordedData.Text = "RECORDED";
                    labelLiveRecordedData.Visible = true;
                });

                buttonSaveCSV.Enabled = true;
                buttonSaveImage.Enabled = true;

                showTemporaryLabelText("Instrument data record loaded successfully.", 5000);
            }
        }
    }
}
