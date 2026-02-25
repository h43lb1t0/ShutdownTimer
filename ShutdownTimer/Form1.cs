using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShutdownTimer {
    public partial class Form1 : Form {
        private readonly Logic logic = new Logic();
        private readonly Timer updateTimer = new Timer();

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1() {
            InitializeComponent();
            updateTimer.Interval = 1000;
            updateTimer.Tick += UpdateTimer_Tick;
            trayMenu.Closed += TrayMenu_Closed;
            customDuratationBox.TextChanged += CustomDurationBox_TextChanged;
        }

        /// <summary>
        /// Handles the form load event.
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">The event data.</param>
        private void Form1_Load(object sender, EventArgs e) {
            HideToTray();
        }

        /// <summary>
        /// Handles the form resize event.
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">The event data.</param>
        private void Form1_Resize(object sender, EventArgs e) {
            if (WindowState == FormWindowState.Minimized) {
                HideToTray();
            }
        }

        /// <summary>
        /// Handles the notify icon double-click event.
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">The event data.</param>
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) {
            ShowFromTray();
        }

        /// <summary>
        /// Handles the exit menu item click event.
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">The event data.</param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            notifyIcon1.Visible = false;
            Application.Exit();
        }

        /// <summary>
        /// Hides the form and minimizes it to the system tray.
        /// </summary>
        private void HideToTray() {
            ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;
            Hide();
            updateTimer.Stop();
        }

        /// <summary>
        /// Shows the form from the system tray.
        /// </summary>
        private void ShowFromTray() {
            Show();
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            Activate();
            updateTimeLabel();
            updateTimer.Start();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e) {
            updateTimeLabel();
        }

        /// <summary>
        /// Handles the tool strip label click event.
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">The event data.</param>
        private void toolStripLabel1_Click(object sender, EventArgs e) {

        }

        /// <summary>
        /// Handles the tray menu opening event.
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">The event data.</param>
        private void trayMenu_Opening(object sender, CancelEventArgs e) {
            updateTimeLabel();
            updateTimer.Start();
            // Update the visibility of the reset timer button based on the shutdown state
            resetTimerBtn.Visible = logic.isShutdownScheduled();
            timeLabel.Visible = logic.isShutdownScheduled();
            UpdateUnitMenuState();
        }

        private void TrayMenu_Closed(object sender, ToolStripDropDownClosedEventArgs e) {
            updateTimer.Stop();
        }

        /// <summary>
        /// Updates the time label with the remaining shutdown time.
        /// </summary>
        private void updateTimeLabel() {
            long timeUntilShutdown = logic.getTimeUntilShutdown();
            if (timeUntilShutdown < 0) {
                timeLabel.Text = "No shutdown";
            } else {
                timeLabel.Text = $"Time remaining: {logic.formatTime(timeUntilShutdown)}";
            }
        }

        /// <summary>
        /// Handles the reset timer button click event.
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">The event data.</param>
        private void ResetTimerBtn_Click(object sender, EventArgs e) {
            logic.cancelShutdown();
            updateTimeLabel();
        }

        /// <summary>
        /// Handles add time menu item click events.
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">The event data.</param>
        private void AddTime_Click(object sender, EventArgs e) {
            ToolStripMenuItem btn = (ToolStripMenuItem)sender;
            long time = long.Parse(btn.Tag.ToString());
            logic.AddTimeInMinutes(time);
            updateTimeLabel();
        }

        /// <summary>
        /// Validates custom duration input to allow only digits and control characters.
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">The event data.</param>
        private void CustomDurationBox_keyPress(object sender, KeyPressEventArgs e) {
            // Allow only digits and control characters (like backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true; // Ignore the input
            }
        }

        private void CustomDurationBox_TextChanged(object sender, EventArgs e) {
            UpdateUnitMenuState();
        }

        private void UpdateUnitMenuState() {
            unitToolStripMenuItem.Enabled = !string.IsNullOrWhiteSpace(customDuratationBox.Text);
        }

        /// <summary>
        /// Handles the set time menu item click event.
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">The event data.</param>
        private void SetTime_Click(object sender, EventArgs e) {
            String timeStr = customDuratationBox.Text;
            long timeInUnit = long.Parse(timeStr);
            long time = 0;
            String timeUnit = ((ToolStripMenuItem)sender).Tag.ToString();
            switch (timeUnit) {
                case "m":
                    time = logic.minutesToSeconds(timeInUnit);
                    break;
                case "h":
                    time = logic.hoursToSeconds(timeInUnit);
                    break;
                case "d":
                    time = logic.daysToSeconds(timeInUnit);
                    break;

            }

            if (time > 0) {
                logic.shutdown(time);
                updateTimeLabel();
            }
        }
    }
}
