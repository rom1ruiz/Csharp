using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Serie_IV
{
    public class BusinessSchedule
    {
        private DateTime _begin;
        private DateTime _end;
        private SortedDictionary<DateTime, DateTime> _schedules = new SortedDictionary<DateTime, DateTime>();

        public BusinessSchedule()
        {
            _begin = new DateTime(2020, 1, 1);
            _end = new DateTime(2030, 12, 31);
            _schedules = new SortedDictionary<DateTime, DateTime>();
            // _businessSchedules.Add(_begin,_end);
        }

        public bool IsEmpty()
        {
            //if (_schedules.Count == 0)
            //{
            //    return true;
            //}
            //return false;
            return _schedules.Count == 0;   
        }

        public void SetRangeOfDates(DateTime begin, DateTime end)
        {
            if (IsEmpty() && begin < end)
            {
                _begin = begin;
                _end = end;
            }
            else
            {
                throw new ArgumentException("Date invalide");
            }



        }

        private KeyValuePair<DateTime, DateTime> ClosestElements(DateTime beginMeeting)
        {
            DateTime debut = new DateTime();
            DateTime debutAlt = new DateTime();
            foreach (KeyValuePair<DateTime, DateTime> date in _schedules)
            {
                if (date.Key <= beginMeeting)
                {
                    debut = date.Key;
                }
                if (date.Key > beginMeeting)
                {
                    debutAlt = date.Value;
                }
            }
            return new KeyValuePair<DateTime, DateTime>(debut, debutAlt);
        }

        public bool AddBusinessMeeting(DateTime date, TimeSpan duration)
        {
            DateTime datefin = date + duration;
            if (IsEmpty() && date >= _begin && datefin <= _end)
            {
                _schedules.Add(date, datefin);
                return true;

            }
            else if (!IsEmpty() && date >= _begin && datefin <= _end)
            {
                KeyValuePair<DateTime, DateTime> nextDate = ClosestElements(date);
                if (nextDate.Key != DateTime.MinValue || nextDate.Key < date 
                    && 
                    nextDate.Value != DateTime.MinValue || nextDate.Value < datefin)
                {
                    _schedules.Add(date, datefin);
                    return true;
                }
            }
            return false;
        }

        public bool DeleteBusinessMeeting(DateTime date, TimeSpan duration)
        {
            DateTime datefin = date + duration;
            foreach (KeyValuePair<DateTime, DateTime> schedule in _schedules)
            {
                if (schedule.Key <= date && schedule.Value <= datefin)
                {
                    _schedules.Remove(schedule.Key);
                    _schedules.Remove(schedule.Value);
                    return true;
                }

            }
            return false;
        }

        public int ClearMeetingPeriod(DateTime begin, DateTime end)
        {
            int count = 0;
            foreach (DateTime schedule in _schedules.Keys.ToList())
            {
                if (schedule < end && (schedule > begin ||  _schedules[schedule] > begin)) 
                {
                    _schedules.Remove(schedule);
                    count++;
                }
            }

            return count;
        }

        public void DisplayMeetings()
        {
            //TODO
            string line = $"Emploi du temps : {_begin} - {_end}";
            string sline = string.Empty.PadLeft(line.Length, '-');
            Console.WriteLine(line);
            Console.WriteLine(sline);
            if (!IsEmpty())
            {
                foreach (KeyValuePair<DateTime, DateTime> date in _schedules)
                {
                    Console.WriteLine($"{date.Key} - {date.Value}");
                }

            }
            else
            {
                Console.WriteLine("Pas de réunion programmées");

            }
            Console.WriteLine(sline);

        }
    }
}
