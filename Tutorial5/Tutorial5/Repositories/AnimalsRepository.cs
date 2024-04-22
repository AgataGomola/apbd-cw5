using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Tutorial5.Models;
using Tutorial5.Models.DTOs;

namespace Tutorial5.Repositories;

public class AnimalsRepository : IAnimalsRepositories
{
   private IConfiguration _configuration;

   public AnimalsRepository(IConfiguration configuration)
   {
      _configuration = configuration;
   }


   public IEnumerable<Animal> GetAnimals()
   {
      using var connection = new SqlConnection(_configuration.GetConnectionString("Default"));
      connection.Open();
      
      using var command = new SqlCommand();
      command.Connection = connection;
      command.CommandText = "SELECT * FROM Animal";
      
      var reader = command.ExecuteReader();

      var animals = new List<Animal>();

      int idAnimalOrdinal = reader.GetOrdinal("IdAnimal");
      int nameOrdinal = reader.GetOrdinal("Name");
      int areaOrdinal = reader.GetOrdinal("Area");
      int categoryOrdinal = reader.GetOrdinal("Category");
      int descriptionOrdinal = reader.GetOrdinal("Description");
        
        
      while (reader.Read())
      {
         animals.Add(new Animal()
         {
            IdAnimal = reader.GetInt32(idAnimalOrdinal),
            Name = reader.GetString(nameOrdinal),
            Area = reader.GetString(areaOrdinal),
            Category = reader.GetString(categoryOrdinal),
            Description = reader.GetString(descriptionOrdinal)
         });
      }

      return animals;
   }

   public int CreateAnimal(AddAnimal animal)
   {
      using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
      connection.Open();
      
      using var command = new SqlCommand();
      command.Connection = connection;
      command.CommandText = "INSERT INTO Animal (Name, Description, Category, Area) VALUES (@Name, @Description, @Category, @Area)";
      command.Parameters.AddWithValue("@IdAnimal", animal.IdAnimal);
      command.Parameters.AddWithValue("@Name", animal.Name);
      command.Parameters.AddWithValue("@Description", animal.Description);
      command.Parameters.AddWithValue("@Category", animal.Category);
      command.Parameters.AddWithValue("@Area", animal.Area);
      
      var affectedCount =command.ExecuteNonQuery();
      return affectedCount;
   }

   public int UpdateAnimal(AddAnimal animal)
   {
      using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
      connection.Open();
      
      using var command = new SqlCommand();
      command.Connection = connection;
      command.CommandText = "UPDATE Animal SET Name=@Name, Description=@Description, Category=@Category, Area=@Area WHERE IdAnimal=@IdAnimal";
      command.Parameters.AddWithValue("@IdAnimal", animal.IdAnimal);
      command.Parameters.AddWithValue("@Name", animal.Name);
      command.Parameters.AddWithValue("@Description", animal.Description);
      command.Parameters.AddWithValue("@Category", animal.Category);
      command.Parameters.AddWithValue("@Area", animal.Area);
      
      var affectedCount =command.ExecuteNonQuery();
      return affectedCount;
   }

   public int DeleteAnimal(int id)
   {
      using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
      connection.Open();
      
      using var command = new SqlCommand();
      command.Connection = connection;
      command.CommandText = "DELETE Animal FROM Animals WHERE IdAnimal=@IdAnimal";
      command.Parameters.AddWithValue("@IdAnimal", id);

      var affectedCount = command.ExecuteNonQuery();
      return affectedCount;
   }
}