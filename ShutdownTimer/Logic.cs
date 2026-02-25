using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShutdownTimer {
    public class Logic
    {
        private DateTime? shutdownAt;
        private TimeSpan day = TimeSpan.FromDays(1);
        private TimeSpan year = TimeSpan.FromDays(365);


        /// <summary>
        /// Schedules a system shutdown after the specified delay in seconds.
        /// </summary>
        /// <param name="time">The delay in seconds before shutdown.</param>
        public void shutdown(long time)
        {
            System.Diagnostics.Process.Start("shutdown", $"-s -t {time}");
            shutdownAt = DateTime.Now.AddSeconds(time);
        }

        /// <summary>
        /// Cancels any pending system shutdown and clears the timer.
        /// </summary>
        public void cancelShutdown()
        {
            System.Diagnostics.Process.Start("shutdown", "-a");
            shutdownAt = null;
        }


        /// <summary>
        /// Gets the remaining time until shutdown, in seconds.
        /// </summary>
        /// <returns>The remaining seconds, or -1 if no shutdown is scheduled.</returns>
        public long getTimeUntilShutdown()
        {
            if (!shutdownAt.HasValue)
            {
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
        public string formatTime(long time)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(time);
            if (timeSpan > day)
            {
                if (timeSpan > year)
                {
                    int years = timeSpan.Days / 365;
                    int days = timeSpan.Days % 365;
                    return $"{years:00}:{days:00}:{timeSpan.Hours:00}:{timeSpan.Minutes:00}:{timeSpan.Seconds:00}";
                }
                return timeSpan.ToString(@"dd\:hh\:mm\:ss");
            }
            return timeSpan.ToString(@"hh\:mm\:ss");
        }


        /// <summary>
        /// Converts minutes to seconds.
        /// </summary>
        /// <param name="minutes">The number of minutes.</param>
        /// <returns>The number of seconds.</returns>
        public long minutesToSeconds(long minutes)
        {
            return minutes * 60;
        }

        /// <summary>
        /// Converts hours to seconds.
        /// </summary>
        /// <param name="hours">The number of hours.</param>
        /// <returns>The number of seconds.</returns>
        public long hoursToSeconds(long hours)
        {
            return hours * 3600;
        }

        /// <summary>
        /// Converts days to seconds.
        /// </summary>
        /// <param name="days">The number of days.</param>
        /// <returns>The number of seconds.</returns>
        public long daysToSeconds(long days)
        {
            return days * 86400;
        }

        /// <summary>
        /// Adds the specified number of minutes to the current shutdown timer.
        /// </summary>
        /// <param name="time">The number of minutes to add.</param>
        public bool AddTimeInMinutes(long time)
        {
            long seconds = minutesToSeconds(time);
            if (CheckIfScheduledTimeWouldExtend10Years(seconds)) {
                return false;
             }
            long currentTime = getTimeUntilShutdown();
            if (currentTime < 0)
            {
                shutdown(seconds);
            }
            else
            {
                shutdown(currentTime + seconds);
            }
            return true;
        }

        /// <summary>
        /// Determines whether a system shutdown has been scheduled.
        /// </summary>
        /// <returns>Returns <see langword="true"/> if a shutdown is scheduled; otherwise, <see langword="false"/>.</returns>
        public bool isShutdownScheduled()
        {
            return shutdownAt.HasValue;
        }

        /// <summary>
        /// Determines whether adding the specified number of seconds to the scheduled shutdown time would result in a
        /// shutdown time that exceeds ten years from the current date and time.
        /// </summary>
        /// <remarks>If a shutdown is already scheduled, the calculation is based on the scheduled time;
        /// otherwise, it uses the current time. This method can be used to enforce a maximum scheduling window for
        /// shutdown operations.</remarks>
        /// <param name="additionalSeconds">The number of seconds to add to the current or scheduled shutdown time. Must be a non-negative value.</param>
        /// <returns>true if the resulting shutdown time would be more than ten years from now; otherwise, false.</returns>
        public bool CheckIfScheduledTimeWouldExtend10Years(long additionalSeconds)
        {
            DateTime newShutdownTime = (!shutdownAt.HasValue) ? shutdownAt.Value.AddSeconds(additionalSeconds) : DateTime.Now.AddSeconds(additionalSeconds);
            DateTime maxAllowedTime = DateTime.Now.AddYears(10);
            return newShutdownTime > maxAllowedTime;
        }

    }
}
