﻿using System;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;

namespace ConsoleSpeech01
{
    class Program
    {
        public static async Task RecognizeSpeechAsync()
        {
            // Creates an instance of a speech factory with specified
            // subscription key and service region. Replace with your own subscription key
            // and service region (e.g., "westus").
            var factory = SpeechFactory.FromSubscription("dd41d32b61dd4fa4b1e24125a176a7cf", "westus");

            // Creates a speech recognizer.
            using (var recognizer = factory.CreateSpeechRecognizer())
            {
                Console.WriteLine("Say something...");

                // Performs recognition.
                // RecognizeAsync() returns when the first utterance has been recognized, so it is suitable 
                // only for single shot recognition like command or query. For long-running recognition, use
                // StartContinuousRecognitionAsync() instead.
                var result = await recognizer.RecognizeAsync();

                // Checks result.
                if (result.RecognitionStatus != RecognitionStatus.Recognized)
                {
                    Console.WriteLine($"Recognition status: {result.RecognitionStatus.ToString()}");
                    if (result.RecognitionStatus == RecognitionStatus.Canceled)
                    {
                        Console.WriteLine($"There was an error, reason: {result.RecognitionFailureReason}");
                    }
                    else
                    {
                        Console.WriteLine("No speech could be recognized.\n");
                    }
                }
                else
                {
                    Console.WriteLine($"We recognized: {result.Text}");
                }
            }
        }

        static void Main()
        {
            RecognizeSpeechAsync().Wait();
            Console.WriteLine("Please press a key to continue.");
            Console.ReadLine();
        }
    }
}
