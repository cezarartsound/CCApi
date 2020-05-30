using CCApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using pt.portugal.eid;

namespace CCApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CCController : ControllerBase
    {
        public ActionResult Get()
        {
            // DOC: https://amagovpt.github.io/autenticacao.gov/manual_sdk.html#windows

            try
            {
                PTEID_ReaderContext readerContext = PTEID_ReaderSet.instance().getReader();
                PTEID_EIDCard card = readerContext.getEIDCard();

                var data = GetData(card);

                return Ok(data);
            }
            catch (PTEID_ExNoCardPresent)
            {
                return NotFound();
            }
        }

        private static CCAddress GetAddress(PTEID_EIDCard card)
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

        private static CCData GetData(PTEID_EIDCard card)
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
                Address = GetAddress(card),
                Photo = eid.getPhotoObj()?.getphoto()?.GetBytes(),
            };
        }
    }
}
