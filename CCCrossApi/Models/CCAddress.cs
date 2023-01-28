using pt.portugal.eid;

namespace CCCrossApi.Models;

public class CCAddress
{
  public string? Municipality { get; set; } // LOURES
  public string? PostalLocality { get; set; } // SANTA IRIA DE AZOIA
  public string? Place { get; set; } // QUINTA DO CASTELO
  public string? StreetName { get; set; } // JOSE FERREIRA CLETO
  public string? StreetType { get; set; } // RUA
  public string? Side { get; set; } // DIREITO
  public string? Locality { get; set; } // SANTA IRIA DE AZOIA
  public string? Floor { get; set; } // 3
  public string? DoorNo { get; set; } // 9
  public string? District { get; set; } // LISBOA
  public string? CountryCode { get; set; } // PT
  public string? ZipCode { get; set; }

  public static CCAddress? Get(PTEID_EIDCard card)
  {
    var pins = card.getPins();
    var pin = pins.getPinByPinRef(PTEID_Pin.ADDR_PIN);
    uint triesLeft = 0;

    if (pin.getTriesLeft() > 1 && pin.verifyPin("0000", ref triesLeft, true))
    {
      var addr = card.getAddr();

      return new CCAddress
      {
        Municipality = addr.getMunicipality(),
        PostalLocality = addr.getPostalLocality(),
        Place = addr.getPlace(),
        StreetName = addr.getStreetName(),
        StreetType = addr.getStreetType(),
        Side = addr.getSide(),
        Locality = addr.getLocality(),
        Floor = addr.getFloor(),
        DoorNo = addr.getDoorNo(),
        District = addr.getDistrict(),
        CountryCode = addr.getCountryCode(),
      };
    }

    return null;
  }
}
