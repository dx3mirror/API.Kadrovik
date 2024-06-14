
using Domain.ValueObject;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public partial class Family
    {
        private int id;
        private int? fkSotrudnik;
        private string fio;
        private StepenRodstvaValueObject stepenRodstva;
        private DateTime? dataRojdeniya;

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

        [StringLength(200)]
        public string Fio
        {
            get { return fio; }
            set { fio = value; }
        }

        public StepenRodstvaValueObject StepenRodstva
        {
            get { return stepenRodstva; }
            set { stepenRodstva = value; }
        }

        public DateTime? DataRojdeniya
        {
            get { return dataRojdeniya; }
            set
            {
                if (value < new DateTime(1960, 1, 1) || value > DateTime.Today)
                {
                    throw new ArgumentException("Дата рождения должна быть не меньше 1960 и не больше сегодняшней");
                }
                dataRojdeniya = value;
            }
        }

        public Family()
        {
            this.Id = -1;
            this.FkSotrudnik = null;
            this.Fio = null;
            this.StepenRodstva = null;
            this.DataRojdeniya = null;
        }

        public Family(int id, int? fkSotrudnik, string fio, StepenRodstvaValueObject stepenRodstva, DateTime? dataRojdeniya)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Недопустимое значение Id");
            }

            this.Id = id;
            this.FkSotrudnik = fkSotrudnik;
            this.Fio = fio;
            this.StepenRodstva = stepenRodstva;
            this.DataRojdeniya = dataRojdeniya;

            if (dataRojdeniya < new DateTime(1960, 1, 1) || dataRojdeniya > DateTime.Today)
            {
                throw new ArgumentException("Дата рождения должна быть не меньше 1960 и не больше сегодняшней");
            }
        }
    }
}
