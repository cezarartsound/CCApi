using pt.portugal.eid;

namespace CCCrossApi.Models;

public class CCData
{
  public string? GivenName { get; set; } // FABIO CLAUDIO
  public string? DocumentNumber { get; set; } // 13779751 6 ZX0
  public string? Surname { get; set; } // PAIVA CARDOSO
  public string? Gender { get; set; } // M
  public string? DateOfBirth { get; set; } // 09 11 1990
  public string? Height { get; set; } // 1,66
  public string? Nationality { get; set; } // PRT
  public string? Country { get; set; } // PRT
  public string? Parents { get; set; } // ALBERTO PINTO CARDOSO * CLARINDA DE PAIVA GOMES
  public string? TaxNo { get; set; } // 252620011
  public string? CivilianIdNumber { get; set; } // 137797516
  public string? HealthNumber { get; set; } // 394612005
  public CCAddress? Address { get; set; }
  public byte[]? Photo { get; set; }

  public static CCData Get(PTEID_EIDCard card)
  {
    var eid = card.getID();

    return new CCData
    {
      GivenName = eid.getGivenName(),
      DocumentNumber = eid.getDocumentNumber(),
      Surname = eid.getSurname(),
      Gender = eid.getGender(),
      DateOfBirth = eid.getDateOfBirth(),
      Height = eid.getHeight(),
      Nationality = eid.getNationality(),
      Country = eid.getCountry(),
      Parents = eid.getParents(),
      TaxNo = eid.getTaxNo(),
      CivilianIdNumber = eid.getCivilianIdNumber(),
      HealthNumber = eid.getHealthNumber(),
      Address = CCAddress.Get(card),
      Photo = eid.getPhotoObj()?.getphoto()?.GetBytes(),
    };
  }
}
