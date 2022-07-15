using System;
using Exames.Tasks.Templates;

namespace Exames.Tasks
{
    public class TaskFactory
    {

        public static Task Generate(ITaskBuildable buildable, Random random)
        {
            var corrects = buildable.Corrects;
            var wrongs = buildable.Wrongs;
            var index = random.Next(0, corrects.Length + wrongs.Length);

            var correct = index < corrects.Length;
            var choosen = correct ? corrects : wrongs;
            if (!correct)
            {
                index -= corrects.Length;
            }
            
            return new Task(buildable.Question, choosen[index], correct);
        }
        
    }
}