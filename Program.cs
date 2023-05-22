if (args.Length == 3)
{
    string path = args[0];
    string fileName = args[1];
    string content = args[2];
    int totalFiles = 0;
    int totalLines = 0;
    int totalOccurences = 0;

    string[] files = Directory.GetFiles(path, fileName);

    foreach (string file in files)
    {
        if (File.ReadAllText(file).Contains(content))
        {
            totalFiles++;
            Console.WriteLine(file);

            string[] lines = File.ReadAllLines(file);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(content))
                {
                    totalLines++;

                    string line = lines[i];
                    for (int j = 0; j < line.Length; j++)
                    {
                        if (line.IndexOf(content) != -1)
                        {
                            line = line.Substring(line.IndexOf(content) + (content.Length - 1));
                            totalOccurences++;
                        }
                    }

                    lines[i] = lines[i].Replace(content, $">>>{content.ToUpper()}<<<");
                    Console.WriteLine($"{i + 1}: {lines[i]} ");
                }
            }
        }
    }

    Console.WriteLine("Summary: ");
    Console.WriteLine("Number of found files: " + totalFiles);
    Console.WriteLine("Number of found lines: " + totalLines);
    Console.WriteLine("Number of found occurences: " + totalOccurences);
}
