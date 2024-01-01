/*
    Date: 2023-09-20
    Author: Aaron Newham
    Purpose: Provides helper methods to get access to the MongoDB database and perform operations on the Characters collection
 */

using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPC_Wizard_MVVM.databaseFiles
{
    public class MongoHelper
    {
        // Connection string: string connectionString = "mongodb+srv://aaronnewham03:0Fv6r1Ofg8YfqNEU@cluster0.qkbyhhq.mongodb.net/?retryWrites=true&w=majority";

        private MongoClient client;
        private IMongoDatabase database;

        public MongoHelper(string connectionString, string databaseName)
        {
            client = new MongoClient(connectionString);
            database = client.GetDatabase(databaseName);
        }

        /*--------CREATE Methods--------*/

        public async Task AddCharacterAsync(CharacterSheet character)
        {
            var charactersCollection = database.GetCollection<BsonDocument>("Characters");

            // Serialize the CharacterSheet object to a BsonDocument
            var characterDocument = character.ToBsonDocument();

            // Insert the BsonDocument into the collection asynchronously
            await charactersCollection.InsertOneAsync(characterDocument);

            Console.WriteLine("Character added to the database.");
        }

        /*--------DELETE Methods--------*/

        public void DeleteCharacterById(string characterId)
        {
            var charactersCollection = database.GetCollection<BsonDocument>("Characters");

            // Create a filter to specify which character to delete based on its ID
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(characterId));

            // Delete the character document that matches the filter
            var result = charactersCollection.DeleteOne(filter);

            if (result.DeletedCount > 0)
            {
                Console.WriteLine("Character deleted from the database.");
            }
            else
            {
                Console.WriteLine("Character not found in the database.");
            }
        }

        public void DeleteCharacterByName(string characterName)
        {
            var charactersCollection = database.GetCollection<BsonDocument>("Characters");

            // Create a filter to specify which character to delete based on their name
            var filter = Builders<BsonDocument>.Filter.Eq("CharacterName", characterName);

            // Delete the character document(s) that match the filter
            var result = charactersCollection.DeleteOne(filter);

            if (result.DeletedCount > 0)
            {
                Console.WriteLine("Character deleted from the database");
            }
            else
            {
                Console.WriteLine("No character with the specified name found in the database.");
            }
        }

        /*--------UPDATE Methods--------*/
        public void UpdateCharacterById(string characterId, CharacterSheet updatedCharacter)
        {
            var charactersCollection = database.GetCollection<CharacterSheet>("Characters");

            // Create a filter to specify which character to update based on their name
            var filter = Builders<CharacterSheet>.Filter.Eq("_id", ObjectId.Parse(characterId));

            // Create an update definition to set the fields of the character
            var updateDefinition = Builders<CharacterSheet>.Update
                .Set(c => c.CharacterName, updatedCharacter.CharacterName)
                .Set(c => c.PlayerName, updatedCharacter.PlayerName)
                .Set(c => c.Race, updatedCharacter.Race)
                .Set(c => c.Type, updatedCharacter.Type)
                .Set(c => c.Class, updatedCharacter.Class)
                .Set(c => c.Level, updatedCharacter.Level)
                .Set(c => c.ExperiencePoints, updatedCharacter.ExperiencePoints)
                .Set(c => c.HitPoints, updatedCharacter.HitPoints)
                .Set(c => c.ArmorClass, updatedCharacter.ArmorClass)
                .Set(c => c.Abilities, updatedCharacter.Abilities)
                .Set(c => c.Skills, updatedCharacter.Skills)
                .Set(c => c.Proficiencies, updatedCharacter.Proficiencies)
                .Set(c => c.Equipment, updatedCharacter.Equipment)
                .Set(c => c.Spells, updatedCharacter.Spells);


            // Perform the update operation
            var result = charactersCollection.UpdateOne(filter, updateDefinition);

            if (result.ModifiedCount > 0)
            {
                Console.WriteLine("Character updated in the database.");
            }
            else
            {
                Console.WriteLine("Character not found in the database.");
            }
        }

        public void UpdateCharacterByName(string characterName, CharacterSheet updatedCharacter)
        {
            var charactersCollection = database.GetCollection<CharacterSheet>("Characters");

            // Create a filter to specify which character to update based on their name
            var filter = Builders<CharacterSheet>.Filter.Eq("CharacterName", characterName);

            // Create an update definition to set the fields of the character
            var updateDefinition = Builders<CharacterSheet>.Update
                .Set(c => c.CharacterName, updatedCharacter.CharacterName)
                .Set(c => c.PlayerName, updatedCharacter.PlayerName)
                .Set(c => c.Race, updatedCharacter.Race)
                .Set(c => c.Class, updatedCharacter.Class)
                .Set(c => c.Level, updatedCharacter.Level)
                .Set(c => c.ExperiencePoints, updatedCharacter.ExperiencePoints)
                .Set(c => c.HitPoints, updatedCharacter.HitPoints)
                .Set(c => c.ArmorClass, updatedCharacter.ArmorClass)
                .Set(c => c.Abilities, updatedCharacter.Abilities)
                .Set(c => c.Skills, updatedCharacter.Skills)
                .Set(c => c.Proficiencies, updatedCharacter.Proficiencies)
                .Set(c => c.Equipment, updatedCharacter.Equipment);


            // Perform the update operation
            var result = charactersCollection.UpdateOne(filter, updateDefinition);

            if (result.ModifiedCount > 0)
            {
                Console.WriteLine("Character updated in the database.");
            }
            else
            {
                Console.WriteLine("Character not found in the database.");
            }
        }

        /*---------READ Methods---------*/

        public List<CharacterSheet> GetAllCharacters()
        {
            var charactersCollection = database.GetCollection<CharacterSheet>("Characters");
            return charactersCollection.Find(_ => true).ToList();
        }

        public CharacterSheet GetCharacterByName(string characterName)
        {
            var charactersCollection = database.GetCollection<CharacterSheet>("Characters");

            // Create a filter to specify which character to retrieve based on their name
            var filter = Builders<CharacterSheet>.Filter.Eq("CharacterName", characterName);

            // Find the character that matches the filter and return it
            return charactersCollection.Find(filter).FirstOrDefault();
        }

        public CharacterSheet GetCharacterById(string characterId)
        {
            var charactersCollection = database.GetCollection<CharacterSheet>("Characters");

            // Create a filter to specify which character to retrieve based on their ID
            var filter = Builders<CharacterSheet>.Filter.Eq("_id", ObjectId.Parse(characterId));

            // Find the character that matches the filter and return it
            return charactersCollection.Find(filter).FirstOrDefault();
        }
    }
}
