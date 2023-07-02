using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using backend.Repository.Common;

namespace backend.Utils
{
    public class FileUtil
    {
        private static IAmazonS3? client;

        public static async Task SaveFile(string filePath, IFormFile file)
        {
            if (file.Length > 0)
            {
                Stream fileStream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(fileStream);
            }
        }

        public static async Task WritingAnObjectAsync(string key, string filePath, IPasswordRepository passwordRepository)
        {
            Models.Password password = passwordRepository.GetAwsPassword();
            Console.WriteLine(filePath);
            client = new AmazonS3Client(password.ClientId, password.ClientKey, Constant.Constant.AWS_CLIENT_REGION);
            try
            {
                var putRequest1 = new PutObjectRequest
                {
                    BucketName = Constant.Constant.AWS_BUCKET_NAME,
                    Key = key,
                    InputStream = new FileStream(filePath, FileMode.Open, FileAccess.Read)
                };
                PutObjectResponse response = await client.PutObjectAsync(putRequest1);
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine(
                        "Error encountered ***. Message:'{0}' when writing an object"
                        , e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(
                    "Unknown encountered on server. Message:'{0}' when writing an object"
                    , e.Message);
            }
        }
    }
}
