using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class Experience
    {
        private int id;
        private int? fkSotrudnik;
        private string obchyiDay;
        private string obchyiMonth;
        private string obchyiYear;
        private string nepreryvniyDay;
        private string nepreryvniyMonth;
        private string nepreryvniyYear;
        private string vislugaletDay;
        private string vislugaletMonth;
        private string vislugaletYear;
        private string stajrabotyposostoyaniyna;
        private DateOnly? del;

        public int Id
        {
            get { return id; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Недопустимое значение Id");
                }
                id = value;
            }
        }

        public int? FkSotrudnik
        {
            get { return fkSotrudnik; }
            set { fkSotrudnik = value; }
        }

        [Range(1, 31)]
        public string? ObchyiDay
        {
            get { return obchyiDay; }
            set
            {
                if (!IsValidDay(value))
                {
                    throw new ArgumentException("Недопустимое значение дня");
                }
                obchyiDay = value;
            }
        }

        [Range(1, 12)]
        public string ObchyiMonth
        {
            get { return obchyiMonth; }
            set
            {
                if (!IsValidMonth(value))
                {
                    throw new ArgumentException("Недопустимое значение месяца");
                }
                obchyiMonth = value;
            }
        }

        [Range(1, 9999)]
        public string ObchyiYear
        {
            get { return obchyiYear; }
            set
            {
                if (!IsValidYear(value))
                {
                    throw new ArgumentException("Недопустимое значение года");
                }
                obchyiYear = value;
            }
        }

        [Range(1, 31)]
        public string NepreryvniyDay
        {
            get { return nepreryvniyDay; }
            set
            {
                if (!IsValidDay(value))
                {
                    throw new ArgumentException("Недопустимое значение дня");
                }
                nepreryvniyDay = value;
            }
        }

        [Range(1, 12)]
        public string NepreryvniyMonth
        {
            get { return nepreryvniyMonth; }
            set
            {
                if (!IsValidMonth(value))
                {
                    throw new ArgumentException("Недопустимое значение месяца");
                }
                nepreryvniyMonth = value;
            }
        }

        [Range(1, 9999)]
        public string NepreryvniyYear
        {
            get { return nepreryvniyYear; }
            set
            {
                if (!IsValidYear(value))
                {
                    throw new ArgumentException("Недопустимое значение года");
                }
                nepreryvniyYear = value;
            }
        }

        [Range(1, 31)]
        public string VislugaletDay
        {
            get { return vislugaletDay; }
            set
            {
                if (!IsValidDay(value))
                {
                    throw new ArgumentException("Недопустимое значение дня");
                }
                vislugaletDay = value;
            }
        }

        [Range(1, 12)]
        public string VislugaletMonth
        {
            get { return vislugaletMonth; }
            set
            {
                if (!IsValidMonth(value))
                {
                    throw new ArgumentException("Недопустимое значение месяца");
                }
                vislugaletMonth = value;
            }
        }

        [Range(1, 9999)]
        public string VislugaletYear
        {
            get { return vislugaletYear; }
            set
            {
                if (!IsValidYear(value))
                {
                    throw new ArgumentException("Недопустимое значение года");
                }
                vislugaletYear = value;
            }
        }

        public string Stajrabotyposostoyaniyna
        {
            get { return stajrabotyposostoyaniyna; }
            set { stajrabotyposostoyaniyna = value; }
        }

        public DateOnly? Del
        {
            get { return del; }
            set { del = value; }
        }

        public Experience()
        {
            this.Id = -1;
            this.FkSotrudnik = null;
            this.ObchyiDay = null;
            this.ObchyiMonth = null;
            this.ObchyiYear = null;
            this.NepreryvniyDay = null;
            this.NepreryvniyMonth = null;
            this.NepreryvniyYear = null;
            this.VislugaletDay = null;
            this.VislugaletMonth = null;
            this.VislugaletYear = null;
            this.Stajrabotyposostoyaniyna = null;
            this.Del = null;
        }

        public Experience(int id, int? fkSotrudnik, string obchyiDay, string obchyiMonth, string obchyiYear,
                          string nepreryvniyDay, string nepreryvniyMonth, string nepreryvniyYear,
                          string vislugaletDay, string vislugaletMonth, string vislugaletYear,
                          string stajrabotyposostoyaniyna, DateOnly? del)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Недопустимое значение Id");
            }

            this.Id = id;
            this.FkSotrudnik = fkSotrudnik;
            this.ObchyiDay = obchyiDay;
            this.ObchyiMonth = obchyiMonth;
            this.ObchyiYear = obchyiYear;
            this.NepreryvniyDay = nepreryvniyDay;
            this.NepreryvniyMonth = nepreryvniyMonth;
            this.NepreryvniyYear = nepreryvniyYear;
            this.VislugaletDay = vislugaletDay;
            this.VislugaletMonth = vislugaletMonth;
            this.VislugaletYear = vislugaletYear;
            this.Stajrabotyposostoyaniyna = stajrabotyposostoyaniyna;
            this.Del = del;
        }

        private bool IsValidDay(string day)
        {
            if (int.TryParse(day, out int dayValue))
            {
                return dayValue >= 1 && dayValue <= 31;
            }
            return false;
        }

        private bool IsValidMonth(string month)
        {
            if (int.TryParse(month, out int monthValue))
            {
                return monthValue >= 1 && monthValue <= 12;
            }
            return false;
        }

        private bool IsValidYear(string year)
        {
            if (int.TryParse(year, out int yearValue))
            {
                return yearValue >= 1 && yearValue <= 9999;
            }
            return false;
        }
    }
}
