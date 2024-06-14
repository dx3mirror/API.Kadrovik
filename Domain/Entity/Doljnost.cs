using System.ComponentModel.DataAnnotations;


namespace Domain.Entity
{
    public class Doljnost
    {
        private int id;
        private int? fkSotrudnik;
        private string naimenoviyDoljnosti;
        private string sKogo;
        private string poKokoe;
        private int? kolVo;
        private string otvetstveniy;

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

        [StringLength(100)]
        public string NaimenoviyDoljnosti
        {
            get { return naimenoviyDoljnosti; }
            set { naimenoviyDoljnosti = value; }
        }

        [StringLength(50)]
        public string SKogo
        {
            get { return sKogo; }
            set
            {
                if (!IsValidDate(value))
                {
                    throw new ArgumentException("Некорректная дата 'С какого'");
                }
                sKogo = value;
                ValidateDates();
            }
        }

        [StringLength(50)]
        public string PoKokoe
        {
            get { return poKokoe; }
            set
            {
                if (!IsValidDate(value))
                {
                    throw new ArgumentException("Некорректная дата 'По какое'");
                }
                poKokoe = value;
                ValidateDates();
            }
        }

        public int? KolVo
        {
            get { return kolVo; }
            set { kolVo = value; }
        }

        [StringLength(200)]
        public string Otvetstveniy
        {
            get { return otvetstveniy; }
            set { otvetstveniy = value; }
        }

        public Doljnost()
        {
            this.Id = -1;
            this.FkSotrudnik = null;
            this.NaimenoviyDoljnosti = null;
            this.SKogo = null;
            this.PoKokoe = null;
            this.KolVo = null;
            this.Otvetstveniy = null;
        }

        public Doljnost(int id, int? fkSotrudnik, string naimenoviyDoljnosti, string sKogo, string poKokoe, int? kolVo, string otvetstveniy)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Недопустимое значение Id");
            }

            this.Id = id;
            this.FkSotrudnik = fkSotrudnik;
            this.NaimenoviyDoljnosti = naimenoviyDoljnosti;
            this.SKogo = sKogo;
            this.PoKokoe = poKokoe;
            this.KolVo = kolVo;
            this.Otvetstveniy = otvetstveniy;
        }
        private void ValidateDates()
        {
            if (!string.IsNullOrEmpty(SKogo) && !string.IsNullOrEmpty(PoKokoe))
            {
                DateTime startDate;
                DateTime endDate;

                if (DateTime.TryParse(SKogo, out startDate) && DateTime.TryParse(PoKokoe, out endDate))
                {
                    if (endDate < startDate)
                    {
                        throw new ArgumentException("Дата 'По какое' не может быть раньше даты 'С какого'");
                    }
                }
            }
        }

        private bool IsValidDate(string dateStr)
        {
            DateTime date;
            return DateTime.TryParse(dateStr, out date);
        }
    }
}
