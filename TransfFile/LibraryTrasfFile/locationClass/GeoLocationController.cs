using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryTrasfFile.locationClass
{
    public class GeolocationController
    {
        private GeoLocation VerifyLocation(GeoLocation location)
        {
            try
            {
                if (string.IsNullOrEmpty(location.LocationName))
                {
                    throw new Exception("Não é possível salvar uma localização com este nome");
                }
                if (string.IsNullOrEmpty(location.Energy))
                {
                    throw new Exception("Não é possível salvar uma localização sem as características de energia");
                }
                if (string.IsNullOrEmpty(location.Noise))
                {
                    throw new Exception("Não é possível salvar uma localização sem as características de barulho");
                }
                if (string.IsNullOrEmpty(location.Energy))
                {
                    throw new Exception("Não é possível salvar uma localização sem as características de energia");
                }
                if (string.IsNullOrEmpty(location.Price))
                {
                    throw new Exception("Não é possível salvar uma localização sem as características de preço");
                }
                if (string.IsNullOrEmpty(location.Wifi))
                {
                    throw new Exception("Não é possível salvar uma localização sem as características de internet");
                }
                if (location.Longitude == 0)
                {
                    throw new Exception("Não é possível salvar uma localização sem as informaçoes de geolocalizacao - longitude");
                }
                if (location.Latitude == 0)
                {
                    throw new Exception("Não é possível salvar uma localização sem as informaçoes de geolocalizacao - latitude");
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Erro!\n"+ ex.Message);
            }


            return location;
        }


        public List<GeoLocation> ListLocation(string local)
        {


            return new GeoLocationData().ListGeoLocation().Where(c => c.LocationName.Contains(local)).ToList();

        }

        public List<GeoLocation> ListLocation()
        {
            return new GeoLocationData().ListGeoLocation();

        }

        public GeoLocation GetGeoLocation(int id)
        {
            return new GeoLocationData().GetGeoLocation(id);
        }

        public bool InsertLocation(GeoLocation local)
        {
            if (local.LocationId > 0)
            {

                return new GeoLocationData().EditGeoLocation(local);
            }
            else
            {
                return new GeoLocationData().InsertGeoLocation(VerifyLocation(local));
            }

        }
    }

}

