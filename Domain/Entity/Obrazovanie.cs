using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Obrazovanie
    {
        private int id;
        private int? fkSotrudnik;
        private string obrazovanie1;
        private string nazvanieuchrejdeniya;
        private string kvalifikachiyapoObrazovaniyu;
        private string nazvanieuchrejdeniya2;
        private string kvalifikachiyapoObrazovaniyu2;
        private string poslevuzovoe;
        private string professiaOsnova;
        private string professiaDopolnitel;

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
        public string Obrazovanie1
        {
            get { return obrazovanie1; }
            set { obrazovanie1 = value; }
        }

        [StringLength(200)]
        public string Nazvanieuchrejdeniya
        {
            get { return nazvanieuchrejdeniya; }
            set { nazvanieuchrejdeniya = value; }
        }

        [StringLength(200)]
        public string KvalifikachiyapoObrazovaniyu
        {
            get { return kvalifikachiyapoObrazovaniyu; }
            set { kvalifikachiyapoObrazovaniyu = value; }
        }

        [StringLength(200)]
        public string Nazvanieuchrejdeniya2
        {
            get { return nazvanieuchrejdeniya2; }
            set { nazvanieuchrejdeniya2 = value; }
        }

        [StringLength(200)]
        public string KvalifikachiyapoObrazovaniyu2
        {
            get { return kvalifikachiyapoObrazovaniyu2; }
            set { kvalifikachiyapoObrazovaniyu2 = value; }
        }

        [StringLength(200)]
        public string Poslevuzovoe
        {
            get { return poslevuzovoe; }
            set { poslevuzovoe = value; }
        }

        [StringLength(100)]
        public string ProfessiaOsnova
        {
            get { return professiaOsnova; }
            set { professiaOsnova = value; }
        }

        [StringLength(100)]
        public string ProfessiaDopolnitel
        {
            get { return professiaDopolnitel; }
            set { professiaDopolnitel = value; }
        }

        public Obrazovanie()
        {
            this.Id = -1;
            this.FkSotrudnik = null;
            this.Obrazovanie1 = null;
            this.Nazvanieuchrejdeniya = null;
            this.KvalifikachiyapoObrazovaniyu = null;
            this.Nazvanieuchrejdeniya2 = null;
            this.KvalifikachiyapoObrazovaniyu2 = null;
            this.Poslevuzovoe = null;
            this.ProfessiaOsnova = null;
            this.ProfessiaDopolnitel = null;
        }

        public Obrazovanie(int id, int? fkSotrudnik, string obrazovanie1, string nazvanieuchrejdeniya, string kvalifikachiyapoObrazovaniyu,
                           string nazvanieuchrejdeniya2, string kvalifikachiyapoObrazovaniyu2, string poslevuzovoe, string professiaOsnova, string professiaDopolnitel)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Недопустимое значение Id");
            }

            this.Id = id;
            this.FkSotrudnik = fkSotrudnik;
            this.Obrazovanie1 = obrazovanie1;
            this.Nazvanieuchrejdeniya = nazvanieuchrejdeniya;
            this.KvalifikachiyapoObrazovaniyu = kvalifikachiyapoObrazovaniyu;
            this.Nazvanieuchrejdeniya2 = nazvanieuchrejdeniya2;
            this.KvalifikachiyapoObrazovaniyu2 = kvalifikachiyapoObrazovaniyu2;
            this.Poslevuzovoe = poslevuzovoe;
            this.ProfessiaOsnova = professiaOsnova;
            this.ProfessiaDopolnitel = professiaDopolnitel;
        }
    }
}
