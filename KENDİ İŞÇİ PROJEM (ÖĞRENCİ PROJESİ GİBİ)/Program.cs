using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace KENDİ_İŞÇİ_PROJEM__ÖĞRENCİ_PROJESİ_GİBİ_
{
    class Program
    {
        static void Main(string[] args)
        {
            basadön:
            Console.WriteLine("Yeni İşci kayıtı için (1) basınız. ");
            Console.WriteLine("İşci bilgilerini güncelleme için (2) basınız. ");
            Console.WriteLine("İşci kayıtı silmek için (3) basınız. ");
            Console.WriteLine("İşci bölüm değişikliği için (4) basınız. ");
            Console.WriteLine("Çıkış için (5) basınız.");
            string seçim = Console.ReadLine();
            switch (seçim)
            {
                case "1":
                    yeniden:
                    Console.WriteLine("Kayıt olacak işcinin bölümünü giriniz(fırın=1,sırane=2,kalitekontrol=3):");
                    string bölüm = Console.ReadLine();
                    Console.WriteLine("İşci kayıt numarasını giriniz:");
                    string işcino = Console.ReadLine();
                    string bölümhedefyolu = @"c:\İşcibilgileri\" + bölüm;
                    string işciyolu = @"c:\İşcibilgileri\" + bölüm + "\\" + işcino;
                    if (System.IO.Directory.Exists(bölümhedefyolu)==true && System.IO.Directory.Exists(işciyolu)==false)
                    {
                        System.IO.Directory.CreateDirectory(işciyolu);
                        string dosyaadı = işcino + ".txt";
                        string hedefdosyayolu = System.IO.Path.Combine(işciyolu, dosyaadı);
                        System.IO.File.Create(hedefdosyayolu).Close();
                        Console.WriteLine("{0} numaralı işci için dosyaoluşturulmuştur.");
                        Console.WriteLine("İşci adı:");
                        string ad = Console.ReadLine();
                        Console.WriteLine("İşci soyadını:");
                        string soyad = Console.ReadLine();
                        Console.WriteLine("İşci cinsiyeti:");
                        string cinsiyet = Console.ReadLine();
                        Console.WriteLine("İşci tel:");
                        string tel = Console.ReadLine();
                        Console.WriteLine("İşci adresi:");
                        string adres = Console.ReadLine();

                        string[] dizi = { "İşci adı:" + ad, "İşci soyadı:" + soyad, "İşci cinsiyeti:" + cinsiyet, "İşci telefonu:" + tel, "İşci adresi:" + adres };
                        System.IO.File.WriteAllLines(@"c:\İşcibilgileri\" + bölüm + "\\" + işcino+"\\"+işcino+".txt",dizi);
                        Console.WriteLine("Bilgileriniz başar ile kayıtedilmiştir. ");
                        goto yeniden;


                    }
                    if (System.IO.Directory.Exists(bölümhedefyolu)==false)
                    {
                        Console.Clear();
                        Console.WriteLine("Girdiğiniz {0} bölümü bulunamadı tekrar deneyiniz!",bölüm);
                        goto yeniden;
                    }
                    if (System.IO.Directory.Exists(işciyolu)==true)
                    {
                        Console.Clear();
                        Console.WriteLine("{0} numaralı  işci zaten kayıtlı durumda.",işcino);
                        goto yeniden;
                    }
                    break;
                case "2":
                    Basadön:
                    Console.WriteLine("İşci no giriniz:");
                    işcino = Console.ReadLine();
                    System.IO.DirectoryInfo klasörbilgisi = new System.IO.DirectoryInfo("c:\\İşcibilgileri");
                    System.IO.FileInfo[] dosyalar = klasörbilgisi.GetFiles(işcino + ".txt",SearchOption.AllDirectories);
                    int adet = dosyalar.Count();
                    if (adet > 0)
                    {
                        string işcidosyayolu = dosyalar[0].DirectoryName;
                        string işcidosyadı = işcino + ".txt";
                        string hedefklasöryolu = System.IO.Path.Combine(işcidosyayolu, işcidosyadı);
                        string[] işcibilgiler = System.IO.File.ReadAllLines(hedefklasöryolu);
                        foreach (string satırlar in işcibilgiler)
                        {
                            Console.WriteLine(satırlar);
                        }
                        güncelemeyeniden:
                        Console.WriteLine("Telefon no (1)");
                        Console.WriteLine("Adres (2)");
                        Console.WriteLine("Hangi bilgiyi güncelemek istersiniz:");
                        string günceleme = Console.ReadLine();
                        if (günceleme == "1")
                        {
                            Console.WriteLine("Yeni bir telefongiriniz:");
                            işcibilgiler[3] = "İşci telefonu:" + Console.ReadLine();
                            System.IO.File.WriteAllLines(hedefklasöryolu, işcibilgiler);
                            Console.WriteLine("Öğrenci telefonu güncellenmiştir.");
                            foreach (string günceleme1 in işcibilgiler)
                            {
                                Console.WriteLine(günceleme1);
                            }
                            yeniden1:
                            Console.WriteLine("Başkabir bilgi güncelenecekmi (e veya h):");
                            string seçim2 = Console.ReadLine();
                            if (seçim2=="e" || seçim2=="E")
                            {
                                goto güncelemeyeniden;
                            }
                            if (seçim2=="h"||seçim2=="H")
                            {
                                Console.WriteLine("İşleminiz tamamlanmıştır.");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Yanlış harfe bastınız lütfen tekra deneyiniz!");
                                goto yeniden1;
                            }
                        }
                        if (günceleme=="2")
                        {
                            Console.WriteLine("Yeni adres giriniz:");
                            işcibilgiler[3] = "İşci adresi:" + Console.ReadLine();
                            System.IO.File.WriteAllLines(hedefklasöryolu, işcibilgiler);
                            Console.WriteLine("Bilgileriniz güncelenmiştir.");
                            foreach (string satırlar2 in işcibilgiler)
                            {
                                Console.WriteLine(satırlar2);
                            }
                            yeniden3:
                            Console.WriteLine("Başkabir bilgi güncelenecekmi (e veya h):");
                            string seçim2 = Console.ReadLine();
                            if (seçim2 == "e" || seçim2 == "E")
                            {
                                goto güncelemeyeniden;
                            }
                            if (seçim2 == "h" || seçim2 == "H")
                            {
                                Console.WriteLine("İşleminiz tamamlanmıştır.");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Yanlış harfe bastınız lütfen tekra deneyiniz!");
                                goto yeniden3;
                            }

                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Hatalı giriş yaptınız!");
                            goto güncelemeyeniden;
                        }
                       
                    }
                
                    break;
                case "3":
                    Console.WriteLine("Kayıttı silinecek işci  numarası:");
                    işcino = Console.ReadLine();
                    System.IO.DirectoryInfo silinecek = new System.IO.DirectoryInfo("c:\\İşcibilgileri");
                    System.IO.FileInfo[] silinecekdosyalar = silinecek.GetFiles(işcino + ".txt", SearchOption.AllDirectories);
                    int sildosayaadeti = silinecekdosyalar.Count();
                    if (sildosayaadeti>0)
                    {
                        string silinebilecekklasöryolu = silinecekdosyalar[0].DirectoryName;
                        Console.WriteLine(silinebilecekklasöryolu);
                        string[] klasör = silinebilecekklasöryolu.Split("\\");
                        tekrar:
                        Console.WriteLine("{0} bölümündeki {1} numaralı işciyi silmek istiryormusunuz(e veya h):", klasör[2], işcino);
                        string seçim1 = Console.ReadLine();
                        if (seçim1=="e" || seçim1=="E")
                        {
                            System.IO.Directory.Delete(silinebilecekklasöryolu, true); //dizin de bilgi varsa true ekle
                            Console.WriteLine("{0} bölümündeki {1} numaralı işci silinmiştir.", klasör[2], işcino);
                            goto basadön;

                        }
                        if (seçim1=="h" || seçim1=="H")
                        {
                            Console.Clear();
                            Console.WriteLine("Silme işleminiz iptal edilmiştir.");
                            goto basadön;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Hatalı girişyaptınız.");
                            goto tekrar;
                        }
                    }
                    else
                    {
                        Console.WriteLine("{0} numralı Kayıtlı öğrenci bulunamadı", işcino);
                    }
                    break;
                case "4":
                    dönbasa:
                    Console.WriteLine("Bölüm değişikliği yapılacak işci numarası: ");
                    işcino = Console.ReadLine();
                    System.IO.DirectoryInfo taşıma = new System.IO.DirectoryInfo("c:\\İşcibilgileri");
                    System.IO.FileInfo[] dosyayolu = taşıma.GetFiles(işcino + ".txt",System.IO.SearchOption.AllDirectories);
                    int dosayaedet = dosyayolu.Count();
                    if (dosayaedet>0)
                    {
                        string taşınacakklasöyolu = dosyayolu[0].DirectoryName;
                        Console.WriteLine(taşınacakklasöyolu);
                        string[] klasörler = taşınacakklasöyolu.Split("\\");
                        dön2:
                        Console.WriteLine("Hangi bölüme geçiş yapmak istersiniz(fırın:1 ,sırane:2, kalitekontrol:3):");
                        string seçim3 = Console.ReadLine();
                        if (System.IO.Directory.Exists("c:\\İşcibilgileri"+"\\"+seçim3)==true)
                        {
                            dön:
                            Console.WriteLine("{0} numaralı işciyi {1} bölümüne taşımak istiyormusunuz(e veya h):", işcino, seçim3);
                            string karar = Console.ReadLine();
                            if (karar=="e" || karar=="E")
                            {
                                string hedefklasöryolu = @"c:\İşcibilgileri" + "\\" + seçim3 + "\\" + işcino;
                               System.IO. Directory.Move(taşınacakklasöyolu, hedefklasöryolu);
                                Console.WriteLine("{0}numaralı işci {1} bölümüne taşınmıştır.", işcino, seçim3);


                            }
                          else if (karar == "h" || karar == "H")
                            {
                                Console.Clear();
                                Console.WriteLine("Taşıma işlemi iptal edilmiştir.");
                                goto basadön;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Hatalı giriş yaptınız");
                                goto dön;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Girdiğniz {0} bölümü bulunamadı.", seçim3);
                            goto dön2;
                        }


                    }
                   
                    break;
                case "5":
                     Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Yanlış seçim yaptınız!");
                    goto basadön;
                    break;



                        
            }

        }
    }
}
