using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers;

public class FileHelper
{
    public static string Add(IFormFile file, string basePath)
    {
        try
        {
            var result = newPath(file, basePath);
            var sourcePath = Path.GetTempFileName();
            using (var stream = new FileStream(sourcePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            File.Move(sourcePath, result.newPath);
            return result.path2;
        }
        catch (Exception e)
        {

            return e.Message;
        }

    }

    public static string Update(string sourcePath, IFormFile file, string basePath)
    {
        var result = newPath(file, basePath);
        try
        {
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result.newPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            Delete(sourcePath);
        }
        catch (Exception e)
        {
            return e.Message;
        }


        return result.path2;
    }

    public static IDataResult<string> Delete(string path)
    {
        try
        {
            File.Delete(path);
            return new SuccessDataResult<string>("Successfully");
        }
        catch (Exception e)
        {
            return new ErrorDataResult<string>($"Error : {e.Message}");
        }

    }


    private static (string newPath, string path2) newPath(IFormFile file, string basePath)
    {
        string fileExtension = Path.GetExtension(file.FileName);
        var creatingFileName = Guid.NewGuid().ToString("N") + fileExtension;
        var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), $@"wwwroot\Images\" + basePath + $@"\");
        if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
        var result = directoryPath + creatingFileName;
        return (result, $@"\Images\{basePath}\{creatingFileName}");
    }
  
}
