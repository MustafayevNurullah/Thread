using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using Thread.Command.EncryptCommand;

namespace Thread.ViewModel
{
   public class Text:BaseViewModel
    {

      public  Resume resume { get; set; }
       public Pause Pause { get; set; }
        public Stop stop { get; set; }
        public Thread.Command.DecryptCommand.Stop Stop  { get; set; }
        public Thread.Command.DecryptCommand.Pause pause { get; set; }
        public Thread.Command.DecryptCommand.Resume Resume { get; set; }
        public System.Threading.Thread Encrypt_thread;
      public  System.Threading.Thread Dectypt_thread;
        public Text()
        {
            resume = new Resume(this);
            Pause = new Pause(this);
            stop = new Stop(this);
            Stop = new Command.DecryptCommand.Stop(this);
            pause = new Command.DecryptCommand.Pause(this);
            Resume = new Command.DecryptCommand.Resume(this);
            string Name = "The earliest foundations of what would become computer science predate the invention of the modern digital computer. Machines for calculating fixed numerical tasks such as the abacus have existed since antiquity, aiding in computations such as multiplication and division. Algorithms for performing computations have existed since antiquity, even before the development of sophisticated computing equipment"
+ "Wilhelm Schickard designed and constructed the first working mechanical calculator in 1623. In 1673, Gottfried Leibniz demonstrated a digital mechanical calculator, called the Stepped Reckoner.[5] He may be considered the first computer scientist and information theorist, for, among other reasons, documenting the binary number system.In 1820, Thomas de Colmar launched the mechanical calculator industry[note 1] when he released his simplified arithmometer, which was the first calculating machine strong enough and reliable enough to be used daily in an office environment.Charles Babbage started the design of the first automatic mechanical calculator, his Difference Engine, in 1822, which eventually gave him the idea of the first programmable mechanical calculator, his Analytical Engine.[6] He started developing this machine in 1834, and in less than two years, he had sketched out many of the salient features of the modern computer . A crucial step was the adoption of a punched card system derived from the Jacquard loom  making it infinitely programmable  In 1843, during the translation of a French article on the Analytical Engine, Ada Lovelace wrote, in one of the many notes she included, an algorithm to compute the Bernoulli numbers, which is considered to be the first published algorithm ever specifically tailored for implementation on a computer. Around  Herman Hollerith invented the tabulator, which used punched cards to process statistical information; eventually his company became part of IBM.In , one hundred years after Babbage s impossible dream, Howard Aiken convinced IBM, which was making all kinds of punched card equipment and was also in the calculator business  to develop his giant programmable calculator, the ASCC/Harvard Mark I, based on Babbage s Analytical Engine, which itself used cards and a central computing unit.When the machine was finished, some hailed it as Babbages dream come true" +
 "During the 1940s, as new and more powerful computing machines were developed, the term computer came to refer to the machines rather than their human predecessors.[11] As it became clear that computers could be used for more than just mathematical calculations, the field of computer science broadened to study computation in general.In 1945, IBM founded the Watson Scientific Computing Laboratory at Columbia University in New York City.The renovated fraternity house on Manhattan s West Side was IBM s first laboratory devoted to pure science.The lab is the forerunner of IBM s Research Division, which today operates research facilities around the world.[12] Ultimately, the close relationship between IBM and the university was instrumental in the emergence of a new scientific discipline, with Columbia offering one of the first academic-credit courses in computer science in 1946.[13] Computer science began to be established as a distinct academic discipline in the 1950s and early 1960s.[14][15] The worlds first computer science degree program, the Cambridge Diploma in Computer Science, began at the University of Cambridge Computer Laboratory in 1953. The first computer science department in the United States was formed at Purdue University in 1962.[16] Since practical computers became available, many applications of computing have become distinct areas of study in their own rights." +
 " Although many initially believed it was impossible that computers themselves could actually be a scientific field of study, in the late fifties it gradually became accepted among the greater academic population.[17][18] It is the now well-known IBM brand that formed part of the computer science revolution during this time.IBM (short for International Business Machines) released the IBM 704[19] and later the IBM 709[20] computers, which were widely used during the exploration period of such devices. Still, working with the IBM [computer] was frustrating […] if you had misplaced as much as one letter in one instruction, the program would crash, and you would have to start the whole process over againng the late 1950s, the computer science discipline was very much in its developmental stages, and such issues were commonplace." +
" Time has seen significant improvements in the usability and effectiveness of computing technology.[21] Modern society has seen a significant shift in the users of computer technology, from usage only by experts and professionals, to a near-ubiquitous user base. Initially, computers were quite costly, and some degree of humanitarian aid was needed for efficient use—in part from professional computer operators.As computer adoption became more widespread and affordable, less human assistance was needed for common usage";
            //string[] a = Name.Split(' ');
            //for (int i = 0; i < a.Length; i++)
            //{
            //    a[i] = Encrypt_Decrypt.Encrypt_Decrypt.Encrypt(a[i]);
            //}
            //System.IO.File.WriteAllLines("Text.txt", a);

            EncryptList = new ObservableCollection<string>();
             DecryptList = new ObservableCollection<string>();
             Encrypt_thread = new System.Threading.Thread(new System.Threading.ThreadStart( Encrypt));
             Dectypt_thread = new System.Threading.Thread(new System.Threading.ThreadStart( Dectypt));
           
        }
      public  void Start()
        {
            if (Encrypt_thread.ThreadState == System.Threading.ThreadState.Unstarted)
            {

                Encrypt_thread.Start();
            }
        }
        public void Start1()
        {
            if (Dectypt_thread.ThreadState == System.Threading.ThreadState.Unstarted && EncryptList.Count!=0)
            {

                Dectypt_thread.Start();
            }
        }
        void Encrypt()
        {
            StreamReader file = new StreamReader("Text.txt");
            string Name;

            while ((Name = file.ReadLine()) != null)
            {
                App.Current.Dispatcher.Invoke(() =>
                EncryptList.Add(Name)
                    );
                System.Threading.Thread.Sleep(1000);
            }
        }
        void Dectypt()
        {
            for (int i = 0; i < EncryptList.Count; i++)
            {
                App.Current.Dispatcher.Invoke(() =>
                 DecryptList.Add(Encrypt_Decrypt.Encrypt_Decrypt.Decrypt(EncryptList[i]))
                    );
                System.Threading.Thread.Sleep(1000);
            }
            Dectypt_thread.Abort(); 
        }
        ObservableCollection<string> encryptList;
        public ObservableCollection<string> EncryptList
        {
            get
            {
                return encryptList;
            }
            set
            {
                encryptList = value;
                OnChangeProperty(new PropertyChangedEventArgs("EncryptList"));
            }
        }
        ObservableCollection<string> decryptList;
        public ObservableCollection<string> DecryptList
        {
            get
            {
                return decryptList;
            }
            set
            {
                decryptList = value;
                OnChangeProperty(new PropertyChangedEventArgs("DecryptList"));
            }
        }
    }
}
