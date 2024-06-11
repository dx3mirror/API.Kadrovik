using Domain.ValueObject;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class Sotrudnik
    {
            private int id;
            private string? lastname;
            private string? firstname;
            private string? patranomic;
            private string? adress;
            private string? mestoRojd;
            private DateTime? datarojdeniy;
            private EnglishKnowledgeCategory? inYz;
            private MaritalStatusType? brak;
            private string? del;
            private string? identityNomer;
            private string? okin;
            private byte[]? avatar;

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

            [StringLength(50)]
            public string? Lastname
            {
                get { return lastname; }
                set { lastname = value; }
            }

            [StringLength(50)]
            public string? Firstname
            {
                get { return firstname; }
                set { firstname = value; }
            }

            [StringLength(50)]
            public string? Patranomic
            {
                get { return patranomic; }
                set { patranomic = value; }
            }

            [StringLength(100)]
            public string? Adress
            {
                get { return adress; }
                set { adress = value; }
            }

            [StringLength(100)]
            public string? MestoRojd
            {
                get { return mestoRojd; }
                set { mestoRojd = value; }
            }

            public DateTime? Datarojdeniy
            {
                get { return datarojdeniy; }
                set
                {
                    if (value.HasValue)
                    {
                        DateTime minDate = new DateTime(1960, 1, 1);
                        DateTime maxDate = DateTime.Today;

                        if (value < minDate || value > maxDate)
                        {
                            throw new ArgumentException($"Дата рождения должна быть между {minDate.ToShortDateString()} и {maxDate.ToShortDateString()}.");
                        }
                    }
                    datarojdeniy = value;
                }
            }

            public EnglishKnowledgeCategory? InYz
            {
                get { return inYz; }
                set { inYz = value; }
            }

            public MaritalStatusType? Brak
            {
                get { return brak; }
                set { brak = value; }
            }

            [StringLength(10)]
            public string? Del
            {
                get { return del; }
                set { del = value; }
            }

            [StringLength(20)]
            public string? IdentityNomer
            {
                get { return identityNomer; }
                set { identityNomer = value; }
            }

            [StringLength(10)]
            public string? Okin
            {
                get { return okin; }
                set { okin = value; }
            }

            public byte[]? Avatar
            {
                get { return avatar; }
                set { avatar = value; }
            }

             public Sotrudnik()
             {
                 this.Id = -1;
                 this.Lastname = null;
                 this.Firstname = null;
                 this.Patranomic = null;
                 this.Adress = null;
                 this.MestoRojd = null;
                 this.Datarojdeniy = null;
                 this.InYz = null;
                 this.Brak = null;
                 this.Del = null;
                 this.IdentityNomer = null;
                 this.Okin = null;
                 this.Avatar = null;
             }

             public Sotrudnik(int id, string? lastname, string? firstname, string? patranomic, string? adress, string? mestoRojd, DateTime? datarojdeniy, EnglishKnowledgeCategory? inYz, MaritalStatusType? brak, string? del, string? identityNomer, string? okin, byte[]? avatar)
             {
                 if (id <= 0)
                 {
                     throw new ArgumentException("Недопустимое значение Id");
                 }

                 this.Id = id;
                 this.Lastname = lastname;
                 this.Firstname = firstname;
                 this.Patranomic = patranomic;
                 this.Adress = adress;
                 this.MestoRojd = mestoRojd;
                 this.Datarojdeniy = datarojdeniy;
                 this.InYz = inYz;
                 this.Brak = brak;
                 this.Del = del;
                 this.IdentityNomer = identityNomer;
                 this.Okin = okin;
                 this.Avatar = avatar;
             }
    }
}
