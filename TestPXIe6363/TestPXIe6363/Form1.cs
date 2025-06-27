using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NationalInstruments.DAQmx;

using Task = NationalInstruments.DAQmx.Task;

namespace TestPXIe6363
{
    public partial class Form1 : Form
    {
        private Task task;
        private AnalogSingleChannelReader analogSingleChannelReader; // lecteur 
        private CancellationTokenSource cancellationTokenSource;  // Source pour annuler la tâche du 2eme thread
        private bool isTaskRunning = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonLire_Click(object sender, EventArgs e)
        {
            if (!isTaskRunning)
            {
                try
                {
                    task = new Task();

                    // Création du canal d'acquisition
                    task.AIChannels.CreateVoltageChannel(
                            "PXI1Slot2/ai0", // nom exact dans NI MAX
                            "Channel",
                            AITerminalConfiguration.Differential, // possible RSE avec masse commune demandé explication
                            -10, 10, // Plage de tension en volts
                            AIVoltageUnits.Volts
                        );

                    // Configure la tâche pour lire de manière continue
                    task.Timing.ConfigureSampleClock(
                        "",
                        1000, // Fréquence d'échantillonnage (1 kHz)
                        SampleClockActiveEdge.Rising,           // à voir 
                        SampleQuantityMode.ContinuousSamples,   // à voir 
                        1000 // Taille du buffer pour les échantillons continus
                    );

                    // Crée le lecteur de données pour lire à partir du stream de la tâche
                    analogSingleChannelReader = new AnalogSingleChannelReader(task.Stream);

                    // Démarre la tâche d'acquisition
                    task.Start();

                    isTaskRunning = true;

                    // Crée le token de cancellation pour arrêter la tâche proprement
                    cancellationTokenSource = new CancellationTokenSource();
                    CancellationToken token = cancellationTokenSource.Token;

                    // Démarre une tâche asynchrone pour la lecture continue
                    System.Threading.Tasks.Task.Run(() => ContinuouslyReadData(token));

                }
                catch (DaqException ex)
                {
                    MessageBox.Show("Erreur DAQmx : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    // Annuler la tâche qui tourne sur le 2eme thread
                    cancellationTokenSource.Cancel();

                    // Arrête la tâche d'acquisition continue
                    task.Stop();
                    task.Dispose();

                    // Met à jour l'état de la tâche
                    isTaskRunning = false;
                    valueDisplay.Text = "Arrêté"; // Affichage de l'état d'arrêt
                }
                catch (DaqException ex)
                {
                    MessageBox.Show("Erreur lors de l'arrêt de la tâche : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ContinuouslyReadData(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    // Lit une seule valeur (à partir du buffer)
                    double valeur = analogSingleChannelReader.ReadSingleSample();

                    // Met à jour l'interface utilisateur sur le thread principal
                    Invoke(new Action(() =>
                    {
                        // Affiche la dernière valeur lue dans un Label
                        valueDisplay.Text = valeur.ToString("0.000") + " V";
                    }));

                    // Attendre un peu avant de lire à nouveau pour ne pas surcharger l'interface utilisateur
                    System.Threading.Thread.Sleep(100); // Pause de 100 ms
                }
            }
            catch (DaqException ex)
            {
                MessageBox.Show("Erreur pendant la lecture continue : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
