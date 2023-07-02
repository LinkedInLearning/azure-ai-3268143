using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voix01
{
    class Program
    {
        static void Main(string[] args)
        {
            // IMPORTANT : Remplacer ici par votre clé de ressource Azure Speech
            var config = SpeechConfig.FromSubscription("0123456789abcdef0123456789abcdef", "francecentral");
            var audio = AudioConfig.FromWavFileInput(@"D:\data\fr_1.WAV.wav");
            //var audio = AudioConfig.FromWavFileInput(@"D:\data\bp_1.WAV.wav");
            
            config.SpeechRecognitionLanguage = "fr-fr";
            //config.SpeechRecognitionLanguage = "pt-br";
            
            using (var recognizer = new SpeechRecognizer(config, audio))
            {
                recognizer.Recognized += (o, e) =>
                {
                    if (e.Result.Reason == ResultReason.RecognizedSpeech)
                    {
                        Console.WriteLine($"{ e.Result.Text }");
                    }
                    else
                    {
                        Console.WriteLine("- " + e.Result.Reason);
                    }

                };
                recognizer.StartContinuousRecognitionAsync().Wait();

                Console.ReadLine();
                recognizer.StopContinuousRecognitionAsync().Wait();
            }
        }
    }
}
