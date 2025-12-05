

using System.Drawing;

string inputFolder = @"Your_File_Path";   // Folder with original images
string outputFolder = @"Your_File_Path"; // Folder for thumbnails

Console.WriteLine("Image Processing Started...\n");

// Create output folder if it doesn’t exist
Directory.CreateDirectory(outputFolder);

// Get all image files from input folder
string[] imageFiles = Directory.GetFiles(inputFolder, "*.*", SearchOption.TopDirectoryOnly);

// Process each image in parallel
Parallel.ForEach(imageFiles, imagePath =>
{
    try
    {
        using (Image original = Image.FromFile(imagePath))
        {
            // Resize to thumbnail (100x100)
            Image thumbnail = original.GetThumbnailImage(100, 100, () => false, IntPtr.Zero);

            // Generate output file path
            string fileName = Path.GetFileNameWithoutExtension(imagePath);
            string outputPath = Path.Combine(outputFolder, fileName + "_thumb.jpg");

            // Save thumbnail
            thumbnail.Save(outputPath);

            Console.WriteLine($"Processed: {Path.GetFileName(imagePath)} -> {outputPath}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error processing {imagePath}: {ex.Message}");
    }
});

Console.WriteLine("\nAll images processed successfully!");
        