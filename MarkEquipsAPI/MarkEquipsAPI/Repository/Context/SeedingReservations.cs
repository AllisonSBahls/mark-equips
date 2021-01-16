using MarkEquipsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using MarkEquipsAPI.Models.Enums;

namespace MarkEquipsAPI.Repository.Context
{
    public class SeedingReservations
    {
        private readonly MarkEquipsContext _context;

        public SeedingReservations(MarkEquipsContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Equipments.Any() ||
                _context.Collaborators.Any() ||
                _context.Schedules.Any())
            {
                return;
            }

            Equipment e1 = new Equipment() {Id = 1, Name="Projetor Dell", Description="Projetor com entrada HDMI", Number=3232, ImageURL="img1.png"};
            Equipment e2 = new Equipment() { Id = 2, Name = "Projetor LG", Description = "Projetor com entrada VGA", Number = 2321, ImageURL = "img2.png" };
            Equipment e3 = new Equipment() { Id = 3, Name = "Laboratório de Informática", Description = "Lab com 30 computadores", Number = 5453, ImageURL = "img3.png" };
            Equipment e4 = new Equipment() { Id = 4, Name = "Laboratório de Solos e Nutrição", Description = "Para curso de Zootecnia e Agronomia", Number = 8977, ImageURL = "img4.png" };
            Equipment e5 = new Equipment() { Id = 5, Name = "Caixa de Som Samsumg", Description = "Entrada P2 e USB", Number = 3234, ImageURL = "img5.png" };
            Equipment e6 = new Equipment() { Id = 6, Name = "Projetor Brother", Description = "Projetor com entrada HDMI", Number = 2376, ImageURL = "img6.png" };
            Equipment e7 = new Equipment() { Id = 7, Name = "Notebook Dell", Description = "Notebook 2gb RAM entreda VGA e HDMI", Number = 6776, ImageURL = "img7.png" };
            Equipment e8 = new Equipment() { Id = 8, Name = "Notebook LG", Description = "Projetor com entrada HDMI", Number = 6765, ImageURL = "img8.png" };
            Equipment e9 = new Equipment() { Id = 9, Name = "Caixa de Som Retry", Description = "Entrada P2 e USB", Number = 5675, ImageURL = "img9.png" };
            Equipment e10 = new Equipment() { Id = 10, Name = "Projetor Dell 2V", Description = "Projetor com entrada VGA", Number = 4554, ImageURL = "img10.png" };

            Collaborator c1 = new Collaborator() { Id = 1, Name = "Allison Sousa Bahls", User = "allison", Password = "asdald123", Permission = LevelPermission.ADMINISTRATOR };
            Collaborator c2 = new Collaborator() { Id = 2, Name = "Amanda Souza", User = "amanda", Password = "1231", Permission = LevelPermission.STANDARD };
            Collaborator c3 = new Collaborator() { Id = 3, Name = "Elizangela Martins", User = "elizangela", Password = "asdd", Permission = LevelPermission.STANDARD };
            Collaborator c4 = new Collaborator() { Id = 4, Name = "Eline Alburquerque", User = "eline", Password = "qewg", Permission = LevelPermission.STANDARD };
            Collaborator c5 = new Collaborator() { Id = 5, Name = "Priscila Fonseca", User = "priscila", Password = "fghf", Permission = LevelPermission.ADMINISTRATOR };

            Schedule m1 = new Schedule() { Id = 1, Period = PeriodDay.MORNING, HourInitial = "08:00:00", HourFinal = "09:00:00"};
            Schedule m2 = new Schedule() { Id = 2, Period = PeriodDay.MORNING, HourInitial = "09:00:00", HourFinal = "10:00:00" };
            Schedule m3 = new Schedule() { Id = 3, Period = PeriodDay.MORNING, HourInitial = "10:00:00", HourFinal = "11:00:00" };
            Schedule t1 = new Schedule() { Id = 4, Period = PeriodDay.EVERNING, HourInitial = "14:00:00", HourFinal = "15:00:00" };
            Schedule t2 = new Schedule() { Id = 5, Period = PeriodDay.EVERNING, HourInitial = "15:00:00", HourFinal = "16:00:00" };
            Schedule t3 = new Schedule() { Id = 6, Period = PeriodDay.EVERNING, HourInitial = "16:00:00", HourFinal = "17:00:00" };
            Schedule n1 = new Schedule() { Id = 7, Period = PeriodDay.NIGHT, HourInitial = "19:00:00", HourFinal = "20:00:00" };
            Schedule n2 = new Schedule() { Id = 8, Period = PeriodDay.NIGHT, HourInitial = "20:00:00", HourFinal = "21:00:00" };
            Schedule n3 = new Schedule() { Id = 9, Period = PeriodDay.NIGHT, HourInitial = "21:00:00", HourFinal = "22:00:00" };

            Reserver r1 = new Reserver() { Id = 1, Date = new DateTime(2021, 1, 10), Collaborator = c1, Equipment = e1 };
            Reserver r2 = new Reserver() { Id = 2, Date = new DateTime(2021, 2, 12), Collaborator = c2, Equipment = e9 };
            Reserver r3 = new Reserver() { Id = 3, Date = new DateTime(2021, 1, 20), Collaborator = c2, Equipment = e2 };
            Reserver r4 = new Reserver() { Id = 4, Date = new DateTime(2021, 3, 15), Collaborator = c4, Equipment = e4 };
            Reserver r5 = new Reserver() { Id = 5, Date = new DateTime(2021, 4, 12), Collaborator = c5, Equipment = e7 };
            Reserver r6 = new Reserver() { Id = 6, Date = new DateTime(2021, 1, 17),  Collaborator = c2, Equipment = e10 };
            Reserver r7 = new Reserver() { Id = 7, Date = new DateTime(2021, 1, 17), Collaborator = c3, Equipment = e10 };
            Reserver r8 = new Reserver() { Id = 8, Date = new DateTime(2021, 1, 10), Collaborator = c4, Equipment = e3 };
            Reserver r9 = new Reserver() { Id = 9, Date = new DateTime(2021, 1, 16),  Collaborator = c1, Equipment = e4 };
            Reserver r10 = new Reserver() { Id =10, Date = new DateTime(2021, 1, 18),  Collaborator = c3, Equipment = e5 };
            Reserver r11 = new Reserver() { Id = 11, Date = new DateTime(2021, 1, 30), Collaborator = c2, Equipment = e6 };
            Reserver r12 = new Reserver() { Id = 12, Date = new DateTime(2021, 1, 28), Collaborator = c3, Equipment = e7 };
            Reserver r13 = new Reserver() { Id = 13, Date = new DateTime(2021, 1, 21),  Collaborator = c4, Equipment = e8 };
            Reserver r14 = new Reserver() { Id = 14, Date = new DateTime(2021, 1, 21),  Collaborator = c5, Equipment = e9 };

            ReserverSchedule rs1 = new ReserverSchedule() { Reserver = r1, Schedule = m1, Status = ReserveStatus.RESERVED };
            ReserverSchedule rs2 = new ReserverSchedule() { Reserver = r2, Schedule = m2, Status = ReserveStatus.RESERVED };
            ReserverSchedule rs3 = new ReserverSchedule() { Reserver = r3, Schedule = m3, Status = ReserveStatus.FINISHED };
            ReserverSchedule rs4 = new ReserverSchedule() { Reserver = r4, Schedule = t2, Status = ReserveStatus.FINISHED };
            ReserverSchedule rs5 = new ReserverSchedule() { Reserver = r5, Schedule = t1, Status = ReserveStatus.RESERVED };
            ReserverSchedule rs6 = new ReserverSchedule() { Reserver = r6, Schedule = t3, Status = ReserveStatus.USING };
            ReserverSchedule rs7 = new ReserverSchedule() { Reserver = r7, Schedule = n1, Status = ReserveStatus.RESERVED };
            ReserverSchedule rs8 = new ReserverSchedule() { Reserver = r8, Schedule = n2, Status = ReserveStatus.USING };
            ReserverSchedule rs9 = new ReserverSchedule() { Reserver = r9, Schedule = n3, Status = ReserveStatus.USING };
            ReserverSchedule rs10 = new ReserverSchedule() { Reserver = r10, Schedule = m1, Status = ReserveStatus.USING };
            ReserverSchedule rs11 = new ReserverSchedule() { Reserver = r11, Schedule = n1, Status = ReserveStatus.RESERVED };
            ReserverSchedule rs12 = new ReserverSchedule() { Reserver = r12, Schedule = t1, Status = ReserveStatus.RESERVED };
            ReserverSchedule rs13 = new ReserverSchedule() { Reserver = r13, Schedule = t3, Status = ReserveStatus.RESERVED };
            ReserverSchedule rs14 = new ReserverSchedule() { Reserver = r14, Schedule = n1, Status = ReserveStatus.RESERVED };
            ReserverSchedule rs15 = new ReserverSchedule() { Reserver = r1, Schedule = m2, Status = ReserveStatus.RESERVED };
            ReserverSchedule rs16 = new ReserverSchedule() { Reserver = r2, Schedule = m3, Status = ReserveStatus.RESERVED };
            ReserverSchedule rs17 = new ReserverSchedule() { Reserver = r4, Schedule = n3, Status = ReserveStatus.RESERVED };
            ReserverSchedule rs18 = new ReserverSchedule() { Reserver = r5, Schedule = n3, Status = ReserveStatus.RESERVED };
            ReserverSchedule rs19 = new ReserverSchedule() { Reserver = r7, Schedule = n3, Status = ReserveStatus.RESERVED };
            ReserverSchedule rs20 = new ReserverSchedule() { Reserver = r14, Schedule = m2, Status = ReserveStatus.RESERVED };


            ReserverSchedule rs21 = new ReserverSchedule() { Reserver = r13, Schedule = m1 };
            ReserverSchedule rs22 = new ReserverSchedule() { Reserver = r10, Schedule = m3 };
            ReserverSchedule rs23 = new ReserverSchedule() { Reserver = r12, Schedule = t2 };
            ReserverSchedule rs24 = new ReserverSchedule() { Reserver = r14, Schedule = t3 };
            ReserverSchedule rs25 = new ReserverSchedule() { Reserver = r5, Schedule = t2 };
            ReserverSchedule rs26 = new ReserverSchedule() { Reserver = r12, Schedule = m1 };
            ReserverSchedule rs27 = new ReserverSchedule() { Reserver = r1, Schedule = m3 };
            ReserverSchedule rs28 = new ReserverSchedule() { Reserver = r4, Schedule = m2 };
            ReserverSchedule rs29 = new ReserverSchedule() { Reserver = r8, Schedule = n3 };
            ReserverSchedule rs30 = new ReserverSchedule() { Reserver = r9, Schedule = m3 };
            ReserverSchedule rs31 = new ReserverSchedule() { Reserver = r10, Schedule = t1 };
            ReserverSchedule rs32 = new ReserverSchedule() { Reserver = r11, Schedule = t1 };


            _context.Equipments.AddRange(e1, e2, e3, e4, e5, e6, e7, e8, e9, e10);
            _context.Collaborators.AddRange(c1, c2, c3, c4, c5);
            _context.Schedules.AddRange(m1, m2, m3, t1, t2, t3, n1, n2, n3);
            _context.Reservations.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14);
            _context.ReserverSchedules.AddRange(rs1, rs2, rs3, rs4, rs5, rs6, rs7, rs8, rs9, rs10, rs11, rs12, rs13, rs14, rs15, rs16, rs17, rs18, rs19, rs20, rs15, rs16, rs17, rs18, rs19, rs20, rs21, rs22, rs23, rs24, rs25, rs26, rs27, rs28, rs29, rs30, rs31, rs32);
            _context.SaveChanges();
            
            //, rs15, rs16,rs17,rs18,rs19,rs20,rs21,rs22,rs23, rs24,rs25,rs26,rs27,rs28,rs29,rs30,rs31,rs32

        }
    }
}
