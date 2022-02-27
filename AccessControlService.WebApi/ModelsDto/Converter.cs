namespace AccessControlService.WebApi.ModelsDto
{
    public class Converter
    {
        /// <summary>
        /// Конвертирование файла в массив byte[]
        /// </summary>
        /// <param name="file"></param>
        /// <returns>Массив байт или null, в случае неудачи</returns>
        public static byte[]? ConvertToBytes(IFormFile? file)
        {
            if (file is not null)
            {
                try
                {
                    using var binaryReader = new BinaryReader(file.OpenReadStream());
                    return binaryReader.ReadBytes((int)file.Length);
                }
                catch (Exception ex)
                { 
                    Console.Error.WriteLine(ex.Message);
                    return null;
                }
            }
            return null;
        }
        /// <summary>
        /// Конвертирование коллекции файлов в коллекцию byte[]
        /// </summary>
        /// <param name="file"></param>
        /// <returns>Коллекция byte[] или null, в случае неудачи</returns>
        public static ICollection<byte[]>? ConvertToCollectionBytes(IFormFileCollection? files)
        {
            if (files is not null)
            {
                try
                {
                    var list = new List<byte[]>();
                    foreach (var file in files)
                    {
                        using var reader = new BinaryReader(file.OpenReadStream());
                        list.Add(reader.ReadBytes((int)file.Length));
                    }
                    return list;
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                    return null;
                }
            }
            return null;
        }
    }
}
