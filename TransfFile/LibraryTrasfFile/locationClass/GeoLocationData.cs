using LibraryTrasfFile.utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace LibraryTrasfFile.locationClass
{
    public class GeoLocationData
	{
		private GeoLocation Carregar(MySqlDataReader dr)
		{
			return new GeoLocation
			{
				LocationId = int.Parse(dr["idLocation"].ToString().Trim()),
				LocationName = dr["name"].ToString().Trim(),
				Latitude = double.Parse(dr["latitude"].ToString().Trim()),
				Longitude = double.Parse(dr["longitude"].ToString().Trim()),
				Energy = dr["energy"].ToString().Trim(),
				Price = dr["price"].ToString().Trim(),
				Noise = dr["noise"].ToString().Trim(),
				Wifi = dr["wifi"].ToString().Trim()
				
			};
		}

        internal bool InsertGeoLocation(GeoLocation location)
		{
			var db = new Connection().Connect();
			int ok;

			try
			{
				db.Open();

				var insert = new MySqlCommand("INSERT INTO location(idLocation, name, latitude, longitude, wifi, energy, noise, price) " +
                    " VALUES (@idLocation,@name,@latitude,@longitude,@wifi,@energy,@noise,@price)", db);

				var param = insert.Parameters;

				param.AddWithValue("@idLocation", location.LocationId);
				param.AddWithValue("@name", location.LocationName);
				param.AddWithValue("@latitude", location.Latitude);
				param.AddWithValue("@longitude", location.Longitude);
				param.AddWithValue("@wifi", location.Wifi);
				param.AddWithValue("@energy", location.Energy);
				param.AddWithValue("@noise", location.Noise);
				param.AddWithValue("@price", location.Price);

				ok = insert.ExecuteNonQuery();

			}
			catch (Exception ex)
			{
				
				throw new Exception("Erro ao inserir Local\n" + ex.Message);

			}
            finally
            {
                db.Close();

            }

            return (ok == 1);

		}

		internal List<GeoLocation> ListGeoLocation()
		{
			var listGeoLocation = new List<GeoLocation>();
            var db = new Connection().Connect();
            try
			{
				db.Open();

				var select = new MySqlCommand("SELECT idLocation, name, latitude, longitude, wifi, energy, noise, price FROM location", db);
				select.ExecuteNonQuery();

				var dr = select.ExecuteReader();

				while (dr.Read())
				{
					listGeoLocation.Add(Carregar(dr));
				}

			}
			catch (Exception ex)
			{
				throw new Exception("Erro ao Listar Pontos: " + ex.Message);
			}
            finally
            {
                db.Close();
            }
			return listGeoLocation;
		}

        internal GeoLocation GetGeoLocation(int id)
        {
            var geoLocation = new GeoLocation();
            var db = new Connection().Connect();
            try
            {
                db.Open();

                var select = new MySqlCommand("SELECT idLocation, name, latitude, longitude, wifi, energy, noise, price FROM location " +
                    "WHERE idLocation = @idLocation", db);
                select.Parameters.AddWithValue("@idLocation", id);
                select.ExecuteNonQuery();

                var dr = select.ExecuteReader();

                if (dr.Read())
                {
                   geoLocation = Carregar(dr);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter esta localizacao: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
            return geoLocation;
        }

        internal bool DeleteGeoLocation(int id)
		{
			int ok;
            var db = new Connection().Connect();
            try
            {
                db.Open();

                var delete = new MySqlCommand("DELETE FROM location WHERE idLocation = @idLocation ", db);
                delete.Parameters.AddWithValue("@idLocation", id);
                ok = delete.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.Close();
            }

			return (ok == 1);

		}

        internal bool EditGeoLocation(GeoLocation location)
        {
            int ok;
            var db = new Connection().Connect();
            try
            {
                db.Open();
                var update = new MySqlCommand("UPDATE location SET name=@name,latitude=@latitude,longitude=@longitude,wifi=@wifi,energy=@energy,noise=@noise,price=@price" +
                    " WHERE idLocation=@idLocation,", db);
                var param = update.Parameters;
                param.AddWithValue("@idLocation", location.LocationId);
                param.AddWithValue("@name", location.LocationName);
                param.AddWithValue("@latitude", location.Latitude);
                param.AddWithValue("@longitude", location.Longitude);
                param.AddWithValue("@wifi", location.Wifi);
                param.AddWithValue("@energy", location.Energy);
                param.AddWithValue("@noise", location.Noise);
                param.AddWithValue("@price", location.Price);

                ok = update.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }
            return (ok == 1);
        }
	}
}
