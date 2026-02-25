using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShutdownTimer {
    public class Logic {
        private DateTime? shutdownAt;


        /// <summary>
        /// Schedules a system shutdown after the specified delay in seconds.
        /// </summary>
        /// <param name="time">The delay in seconds before shutdown.</param>
        public void shutdown(long time) {
            System.Diagnostics.Process.Start("shutdown", $"-s -t {time}");
            shutdownAt = DateTime.Now.AddSeconds(time);
        }

        /// <summary>
        /// Cancels any pending system shutdown and clears the timer.
        /// </summary>
        public void cancelShutdown() {
            System.Diagnostics.Process.Start("shutdown", "-a");
            shutdownAt = null;
        }


        /// <summary>
        /// Gets the remaining time until shutdown, in seconds.
        /// </summary>
        /// <returns>The remaining seconds, or -1 if no shutdown is scheduled.</returns>
        public long getTimeUntilShutdown() {
            if (!shutdownAt.HasValue) {
                return -1;
            }

            var remaining = shutdownAt.Value - DateTime.Now;
            return (long)Math.Max(0, remaining.TotalSeconds);
        }

        /// <summary>
        /// Formats a duration in seconds as an <c>hh:mm:ss</c> string.
        /// </summary>
        /// <param name="time">The duration in seconds.</param>
        /// <returns>A formatted duration string.</returns>
        public string formatTime(long time) {
            TimeSpan timeSpan = TimeSpan.FromSeconds(time);
            return timeSpan.ToString(@"hh\:mm\:ss");
        }


        /// <summary>
        /// Converts minutes to seconds.
        /// </summary>
        /// <param name="minutes">The number of minutes.</param>
        /// <returns>The number of seconds.</returns>
        public long minutesToSeconds(long minutes) {
            return minutes * 60;
        }

        /// <summary>
        /// Converts hours to seconds.
        /// </summary>
        /// <param name="hours">The number of hours.</param>
        /// <returns>The number of seconds.</returns>
        public long hoursToSeconds(long hours) {
            return hours * 3600;
        }

        /// <summary>
        /// Converts days to seconds.
        /// </summary>
        /// <param name="days">The number of days.</param>
        /// <returns>The number of seconds.</returns>
        public long daysToSeconds(long days) {
            return days * 86400;
        }

        /// <summary>
        /// Adds the specified number of minutes to the current shutdown timer.
        /// </summary>
        /// <param name="time">The number of minutes to add.</param>
        public void AddTimeInMinutes(long time) {
            long seconds = minutesToSeconds(time);
            long currentTime = getTimeUntilShutdown();
            if (currentTime < 0) {
                shutdown(seconds);
            } else {
                shutdown(currentTime + seconds);
            }
        }
    }
}
