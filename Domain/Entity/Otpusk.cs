using System.ComponentModel.DataAnnotations;
using Domain.ValueObject;


public partial class Otpusk
{
    private int id;
    private int? fkSotrudnik;
    private VidOtpuskaValueObject vidOtpuska;
    private DateTime? periodS;
    private DateTime? periodPo;
    private string day;
    private DateTime? sKakogo;
    private DateTime? poKakoe;
    private string prichina;

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

    public VidOtpuskaValueObject VidOtpuska
    {
        get { return vidOtpuska; }
        set { vidOtpuska = value; }
    }

    public DateTime? PeriodS
    {
        get { return periodS; }
        set
        {
            if (value != null && PeriodPo != null && value > PeriodPo)
            {
                throw new ArgumentException("Дата 'С' не может быть позже даты 'По'");
            }
            periodS = value;
        }
    }

    public DateTime? PeriodPo
    {
        get { return periodPo; }
        set
        {
            if (value != null && PeriodS != null && value < PeriodS)
            {
                throw new ArgumentException("Дата 'По' не может быть раньше даты 'С'");
            }
            periodPo = value;
        }
    }

    [Range(1, 31)]
    public string Day
    {
        get { return day; }
        set
        {
            if (!IsValidDay(value))
            {
                throw new ArgumentException("Недопустимое значение дня");
            }
            day = value;
        }
    }

    public DateTime? SKakogo
    {
        get { return sKakogo; }
        set
        {
            if (value != null && PoKakoe != null && value > PoKakoe)
            {
                throw new ArgumentException("Дата 'С какого' не может быть позже даты 'По какое'");
            }
            sKakogo = value;
        }
    }

    public DateTime? PoKakoe
    {
        get { return poKakoe; }
        set
        {
            if (value != null && SKakogo != null && value < SKakogo)
            {
                throw new ArgumentException("Дата 'По какое' не может быть раньше даты 'С какого'");
            }
            poKakoe = value;
        }
    }

    public string Prichina
    {
        get { return prichina; }
        set { prichina = value; }
    }

    public Otpusk()
    {
        this.Id = -1;
        this.FkSotrudnik = null;
        this.VidOtpuska = null;
        this.PeriodS = null;
        this.PeriodPo = null;
        this.Day = null;
        this.SKakogo = null;
        this.PoKakoe = null;
        this.Prichina = null;
    }

    public Otpusk(int id, int? fkSotrudnik, VidOtpuskaValueObject vidOtpuska, DateTime? periodS, DateTime? periodPo,
                  string day, DateTime? sKakogo, DateTime? poKakoe, string prichina)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Недопустимое значение Id");
        }

        this.Id = id;
        this.FkSotrudnik = fkSotrudnik;
        this.VidOtpuska = vidOtpuska;
        this.PeriodS = periodS;
        this.PeriodPo = periodPo;
        this.Day = day;
        this.SKakogo = sKakogo;
        this.PoKakoe = poKakoe;
        this.Prichina = prichina;

        ValidateDates();
    }

    private void ValidateDates()
    {
        if (PeriodS != null && PeriodPo != null && PeriodS > PeriodPo)
        {
            throw new ArgumentException("Дата 'С' не может быть позже даты 'По'");
        }

        if (SKakogo != null && PoKakoe != null && SKakogo > PoKakoe)
        {
            throw new ArgumentException("Дата 'С какого' не может быть позже даты 'По какое'");
        }
    }

    private bool IsValidDay(string day)
    {
        if (int.TryParse(day, out int dayValue))
        {
            return dayValue >= 1 && dayValue <= 31;
        }
        return false;
    }
}
