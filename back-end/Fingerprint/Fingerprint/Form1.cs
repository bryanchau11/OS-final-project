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

namespace Fingerprint
{
    public partial class Form1 : Form
    {
        finger_printEntities fpEntities = new finger_printEntities();

        public Form1()
        {
            InitializeComponent();
        }

        List<string> portNames = new List<string>();

        private void button1_Click(object sender, EventArgs e)
        {
            portNames = SerialPort.GetPortNames().ToList();
            comboBox1.DataSource = portNames;
        }

        public string message;
        public bool _continute;
        SerialPort _serialPort;

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            _serialPort = new SerialPort();

            MethodInvoker miReadText = new MethodInvoker(() =>
            {
                _serialPort.PortName = comboBox1.SelectedItem.ToString();
            });

            this.Invoke(miReadText);

            _serialPort.ReadTimeout = 500;
            _serialPort.WriteTimeout = 500;

            _serialPort.Open();
            _continute = true;

            backgroundWorker1.WorkerReportsProgress = true;

            while (_continute)
            {
                try
                {
                    message = _serialPort.ReadLine();
                    backgroundWorker1.ReportProgress(1);
                }
                catch (TimeoutException) { }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            textBox2.Text += message + "\n";

            int fingerID = int.Parse(message);

            if (!fpEntities.Persons.Any(q=>q.fingerID == fingerID))
            {
                Person person = new Person()
                {
                    personName = textBox1.Text,
                    fingerID = fingerID
                };
                fpEntities.Persons.Add(person);
                fpEntities.SaveChanges();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                _continute = false;
                _serialPort.Close();
            }
            finally
            {

            }
        }

        private string portName;

        private void button2_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            portName = comboBox1.SelectedText;
        }
    }
}
