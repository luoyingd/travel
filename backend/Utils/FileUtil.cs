using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using backend.Repository.Common;

namespace backend.Utils
{
    public class FileUtil
    {
        private IAmazonS3? client;

        public FileUtil(IPasswordRepository passwordRepository)
        {
            Models.Password password = passwordRepository.GetAwsPassword();
            client = new AmazonS3Client(password.ClientId, password.ClientKey, Constant.Constant.AWS_CLIENT_REGION);
        }

        public async Task SaveFile(string filePath, IFormFile file)
        {
            if (file.Length > 0)
            {
                Stream fileStream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(fileStream);
            }
        }

        public async Task WritingAnObjectAsync(string key, string filePath)
        {
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

        public async Task ReadObjectDataAsync(string key)
        {
            string responseBody = "";
            try
            {
                GetObjectRequest request = new GetObjectRequest
                {
                    BucketName = Constant.Constant.AWS_BUCKET_NAME,
                    Key = key
                };
                using (GetObjectResponse response = await client.GetObjectAsync(request))
                using (Stream responseStream = response.ResponseStream)
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    string contentType = response.Headers["Content-Type"];
                    Console.WriteLine("Content type: {0}", contentType);

                    responseBody = reader.ReadToEnd(); // Now you process the response body.
                }
            }
            catch (AmazonS3Exception e)
            {
                // If bucket or object does not exist
                Console.WriteLine("Error encountered ***. Message:'{0}' when reading object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when reading object", e.Message);
            }
        }
    }

}

