using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Ejercicio4.Models;
using System.Threading.Tasks;

namespace Ejercicio4.Controller
{
    public class DataBase
    {
        readonly SQLiteAsyncConnection dbase;
        public DataBase(String path)
        {
            dbase = new SQLiteAsyncConnection(path);
            dbase.CreateTableAsync<imagen>();

        }
        #region Operaciones Imagen
        public Task<int> insertUpdateImagen(imagen img)
        {
            if (img.id != 0)
            {
                return dbase.UpdateAsync(img);
            }
            else
            {
                return dbase.InsertAsync(img);
            }
        }
        public Task<List<imagen>> getListImagen()
        {
            return dbase.Table<imagen>().ToListAsync();
        }
        public Task<imagen> getImagen(int id)
        {
            return dbase.Table<imagen>().Where(i => i.id == id).FirstOrDefaultAsync();
        }
        public Task<int> deleteImagen(imagen img)
        {
            return dbase.DeleteAsync(img);
        }
        #endregion OperacionesImagen
    }
}

