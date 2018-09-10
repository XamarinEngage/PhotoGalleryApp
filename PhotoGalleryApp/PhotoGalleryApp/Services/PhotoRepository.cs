using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PhotoGalleryApp.Models;
using SQLite;

namespace PhotoGalleryApp.Services
{
    public class PhotoRepository
    {
        SQLiteAsyncConnection database;

        public PhotoRepository(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<PhotoClass>().Wait();
        }

        public async Task<int> CreatePhoto(PhotoClass Photo)
        {
            return await database.InsertAsync(Photo);
        }

        public async Task<int> DeletePhoto(PhotoClass Photo)
        {
            return await database.DeleteAsync(Photo);
        }

        public async Task<int> UpdatePhoto(PhotoClass Photo)
        {
            //database.GetAsync<PhotoClass>(id)
            PhotoClass editedPhoto = await database.Table<PhotoClass>().Where(c => c.Id == Photo.Id).FirstOrDefaultAsync();            
            {             
                return await database.UpdateAsync(Photo);
            }
        }

        public async Task<PhotoClass> GetPhoto(int id)
        {
            return await database.GetAsync<PhotoClass>(id);
        }

        public async Task<List<PhotoClass>> GetAllPhoto()
        {
            return await database.Table<PhotoClass>().ToListAsync();
        }


    }
}
