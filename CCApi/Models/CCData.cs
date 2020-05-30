
namespace CCApi.Models
{
    public class CCData
    {
        public string GivenName { get; set; } // FABIO CLAUDIO
        public string DocumentNumber { get; set; } // 13779751 6 ZX0
        public string Surname { get; set; } // PAIVA CARDOSO
        public string Gender { get; set; } // M
        public string DateOfBirth { get; set; } // 09 11 1990
        public string Height { get; set; } // 1,66
        public string Nationality { get; set; } // PRT
        public string Country { get; set; } // PRT
        public string Parents { get; set; } // ALBERTO PINTO CARDOSO * CLARINDA DE PAIVA GOMES
        public string TaxNo { get; set; } // 252620011
        public string CivilianIdNumber { get; set; } // 137797516
        public string HealthNumber { get; set; } // 394612005
        public CCAddress Address { get; set; }
        public byte[] Photo { get; set; }
    }
}
