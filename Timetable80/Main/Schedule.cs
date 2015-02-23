using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using NUDispSchedule.Main.FileSave;
using NUDispSchedule.Main.Others;
using System.IO;
using NUDispSchedule.Main.Web;
using Newtonsoft.Json;
using Windows.Storage;
using System.Threading.Tasks;
using InternetTest.Core;

namespace NUDispSchedule.Main
{
    public class Schedule
    {
        public List<Auditorium> auditoriums { get; set; }
        public List<Calendar> calendars { get; set; }
        public List<Discipline> disciplines { get; set; }
        public List<Lesson> lessons { get; set; }
        public List<Ring> rings { get; set; }
        public List<Student> students { get; set; }
        public List<StudentGroup> studentGroups { get; set; }
        public List<StudentsInGroups> studentsInGroups { get; set; }
        public List<Teacher> teachers { get; set; }
        public List<TeacherForDiscipline> teacherForDisciplines { get; set; }
        public List<LessonLogEvent> lessonLogEvents { get; set; }
        public List<ConfigOption> configOptions { get; set; }
        
        public FileSaveSchedule ToFileSchedule()
        {
            var result = new FileSaveSchedule
            {
                auditoriums = new List<Auditorium>(),
                calendars = new List<FileSaveCalendar>(),
                disciplines = new List<WebDiscipline>(),
                lessons = new List<WebLesson>(),
                rings = new List<FileSaveRing>(),
                students = new List<WebStudent>(),
                studentGroups = new List<StudentGroup>(),
                studentsInGroups = new List<WebStudentsInGroups>(),
                teachers = new List<Teacher>(),
                teacherForDisciplines = new List<WebTeacherForDiscipline>(),

                configOptions = new List<ConfigOption>(),
                lessonLogEvents = new List<WebLessonLogEvent>()
            };

            foreach (var a in auditoriums)
            {
                result.auditoriums.Add(a);
            }

            foreach (var c in calendars)
            {
                result.calendars.Add(new FileSaveCalendar
                    {
                        CalendarId = c.CalendarId,
                        Date = c.Date.ToString("dd.MM.yyyy")
                    }
                );
            }

            foreach (var r in rings)
            {
                result.rings.Add(new FileSaveRing{RingId = r.RingId, Time = r.Time.ToString("H:mm")});
            }

            foreach (var sg in studentGroups)
            {
                result.studentGroups.Add(sg);
            }

            foreach (var t in teachers)
            {
                result.teachers.Add(t);
            }

            foreach (var co in configOptions)
            {
                result.configOptions.Add(co);
            }

            foreach (var d in disciplines)
            {
                var newD = new WebDiscipline { 
                    Attestation = d.Attestation,
                    AuditoriumHours = d.AuditoriumHours,
                    DisciplineId = d.DisciplineId,
                    LectureHours = d.LectureHours,
                    Name = d.Name,
                    PracticalHours = d.PracticalHours,
                    StudentGroupId = d.StudentGroup.StudentGroupId
                };

                result.disciplines.Add(newD);
            }

            foreach (var s in students)
            {
                result.students.Add(new WebStudent {
                    StudentId = s.StudentId, 
                    F = s.F, 
                    I = s.I, 
                    O = s.O,
                    Starosta = s.Starosta ? 1 : 0, 
                    NFactor = s.NFactor ? 1 : 0,
                    Expelled = s.Expelled ? 1 : 0
                });
            }

            foreach (var sig in studentsInGroups)
            {
                var stig = new WebStudentsInGroups { 
                    StudentsInGroupsId = sig.StudentsInGroupsId,
                    StudentId = sig.Student.StudentId,
                    StudentGroupId = sig.StudentGroup.StudentGroupId
                };
                result.studentsInGroups.Add(stig);
            }

            foreach (var tfd in teacherForDisciplines)
            {
                var tefd = new WebTeacherForDiscipline { 
                    TeacherForDisciplineId = tfd.TeacherForDisciplineId,
                    TeacherId = tfd.Teacher.TeacherId,
                    DisciplineId = tfd.Discipline.DisciplineId
                };
                result.teacherForDisciplines.Add(tefd);
            }

            foreach (var lesson in lessons)
            {
                var l = new WebLesson { 
                    AuditoriumId = lesson.Auditorium.AuditoriumId,
                    CalendarId = lesson.Calendar.CalendarId,
                    IsActive = lesson.IsActive ? 1 : 0,
                    LessonId = lesson.LessonId,
                    RingId = lesson.Ring.RingId,
                    TeacherForDisciplineId = lesson.TeacherForDiscipline.TeacherForDisciplineId
                };
                result.lessons.Add(l);
            }

            foreach (var logEvent in lessonLogEvents)
            {
                int newLessonId = -1, oldLessonId = -1;
                if (logEvent.NewLesson != null)
                {
                    newLessonId = logEvent.NewLesson.LessonId;
                }
                if (logEvent.OldLesson != null)
                {
                    oldLessonId = logEvent.OldLesson.LessonId;
                }

                var lle = new WebLessonLogEvent { 
                    Comment = logEvent.Comment,
                    DateTime = logEvent.DateTime,
                    LessonLogEventId = logEvent.LessonLogEventId,
                    NewLessonId = newLessonId,
                    OldLessonId = oldLessonId
                };
                result.lessonLogEvents.Add(lle);
            }

            return result;
        }


        static public Schedule FromWebSchedule(WebSchedule ws)
        {
            var result = new Schedule
                             {
                                 auditoriums = new List<Auditorium>(),
                                 calendars = new List<Calendar>(),
                                 disciplines = new List<Discipline>(),
                                 lessons = new List<Lesson>(),
                                 rings = new List<Ring>(),
                                 students = new List<Student>(),
                                 studentGroups = new List<StudentGroup>(),
                                 studentsInGroups = new List<StudentsInGroups>(),
                                 teachers = new List<Teacher>(),
                                 teacherForDisciplines = new List<TeacherForDiscipline>(),

                                 configOptions = new List<ConfigOption>(),
                                 lessonLogEvents = new List<LessonLogEvent>()
                             };

            foreach (var a in ws.auditoriums)
            {
                result.auditoriums.Add(a);
            }

            foreach (var c in ws.calendars)
            {                
                result.calendars.Add(c);
            }

            foreach (var r in ws.rings)
            {
                result.rings.Add(r);
            }

            foreach (var sg in ws.studentGroups)
            {
                result.studentGroups.Add(sg);
            }

            foreach (var t in ws.teachers)
            {
                result.teachers.Add(t);
            }

            foreach (var co in ws.configOptions)
            {
                result.configOptions.Add(co);
            }

            foreach (var d in ws.disciplines)
            {
                var sg = result.studentGroups.FirstOrDefault(stgr => stgr.StudentGroupId == d.StudentGroupId);
                var newD = new Discipline(d.DisciplineId, d.Name, 
                    sg, d.Attestation, d.AuditoriumHours, d.LectureHours, d.PracticalHours);
                
                result.disciplines.Add(newD);
            }

            foreach (var s in ws.students)
            {
                result.students.Add(new Student(s.StudentId, s.F, s.I, s.O, 
                    s.Starosta == 1, s.NFactor == 1, s.Expelled == 1));
            }

            foreach (var sig in ws.studentsInGroups)
            {
                var stud = result.students.FirstOrDefault(s => s.StudentId == sig.StudentId);
                var stgr = result.studentGroups.FirstOrDefault(sg => sg.StudentGroupId == sig.StudentGroupId);
                result.studentsInGroups.Add(new StudentsInGroups
                                                {
                                                    StudentsInGroupsId = sig.StudentsInGroupsId,
                                                    Student = stud, StudentGroup = stgr
                                                });
            }

            foreach (var tfd in ws.teacherForDisciplines)
            {
                var teacher = result.teachers.FirstOrDefault(t => t.TeacherId == tfd.TeacherId);
                var discipline = result.disciplines.FirstOrDefault(d => d.DisciplineId == tfd.DisciplineId);
                result.teacherForDisciplines.Add(new TeacherForDiscipline
                                                     {
                                                         TeacherForDisciplineId = tfd.TeacherForDisciplineId,
                                                         Teacher = teacher, Discipline = discipline
                                                     });
            }

            foreach (var lesson in ws.lessons)
            {
                var tefd = result.teacherForDisciplines.FirstOrDefault(
                        tfd => tfd.TeacherForDisciplineId == lesson.TeacherForDisciplineId);
                var cal = result.calendars.FirstOrDefault(c => c.CalendarId == lesson.CalendarId);
                var ring = result.rings.FirstOrDefault(r => r.RingId == lesson.RingId);
                var aud = result.auditoriums.FirstOrDefault(a => a.AuditoriumId == lesson.AuditoriumId);
                result.lessons.Add(new Lesson(lesson.LessonId, tefd, cal, ring, aud, lesson.IsActive == 1));
            }

            foreach (var logEvent in ws.lessonLogEvents)
            {
                var oldLesson = result.lessons.FirstOrDefault(l => l.LessonId == logEvent.OldLessonId);
                var newLesson = result.lessons.FirstOrDefault(l => l.LessonId == logEvent.NewLessonId);
                result.lessonLogEvents.Add(new LessonLogEvent
                                               {
                                                   LessonLogEventId = logEvent.LessonLogEventId,
                                                   Comment = logEvent.Comment,
                                                   DateTime = logEvent.DateTime,
                                                   NewLesson = newLesson,
                                                   OldLesson = oldLesson

                                               });
            }

            return result;
        }

        static public Schedule FromFileSaveSchedule(FileSaveSchedule fss)
        {
            var result = new Schedule
            {
                auditoriums = new List<Auditorium>(),
                calendars = new List<Calendar>(),
                disciplines = new List<Discipline>(),
                lessons = new List<Lesson>(),
                rings = new List<Ring>(),
                students = new List<Student>(),
                studentGroups = new List<StudentGroup>(),
                studentsInGroups = new List<StudentsInGroups>(),
                teachers = new List<Teacher>(),
                teacherForDisciplines = new List<TeacherForDiscipline>(),

                configOptions = new List<ConfigOption>(),
                lessonLogEvents = new List<LessonLogEvent>()
            };

            foreach (var a in fss.auditoriums)
            {
                result.auditoriums.Add(a);
            }

            foreach (var c in fss.calendars)
            {
                result.calendars.Add(new Calendar
                    {
                        CalendarId = c.CalendarId,
                        Date = new DateTime(
                            int.Parse(c.Date.Substring(6,4)), 
                            int.Parse(c.Date.Substring(3,2)),
                            int.Parse(c.Date.Substring(0,2))
                        )
                    }
                );
            }

            foreach (var r in fss.rings)
            {
                result.rings.Add(new Ring
                {
                    RingId = r.RingId,
                    Time = DateTime.ParseExact(r.Time, "H:mm", CultureInfo.InvariantCulture)
                }
                );
            }

            foreach (var sg in fss.studentGroups)
            {
                result.studentGroups.Add(sg);
            }

            foreach (var t in fss.teachers)
            {
                result.teachers.Add(t);
            }

            foreach (var co in fss.configOptions)
            {
                result.configOptions.Add(co);
            }

            foreach (var d in fss.disciplines)
            {
                var sg = result.studentGroups.FirstOrDefault(stgr => stgr.StudentGroupId == d.StudentGroupId);
                var newD = new Discipline(d.DisciplineId, d.Name,
                    sg, d.Attestation, d.AuditoriumHours, d.LectureHours, d.PracticalHours);

                result.disciplines.Add(newD);
            }

            foreach (var s in fss.students)
            {
                result.students.Add(new Student(s.StudentId, s.F, s.I, s.O,
                    s.Starosta == 1, s.NFactor == 1, s.Expelled == 1));
            }

            foreach (var sig in fss.studentsInGroups)
            {
                var stud = result.students.FirstOrDefault(s => s.StudentId == sig.StudentId);
                var stgr = result.studentGroups.FirstOrDefault(sg => sg.StudentGroupId == sig.StudentGroupId);
                result.studentsInGroups.Add(new StudentsInGroups
                {
                    StudentsInGroupsId = sig.StudentsInGroupsId,
                    Student = stud,
                    StudentGroup = stgr
                });
            }

            foreach (var tfd in fss.teacherForDisciplines)
            {
                var teacher = result.teachers.FirstOrDefault(t => t.TeacherId == tfd.TeacherId);
                var discipline = result.disciplines.FirstOrDefault(d => d.DisciplineId == tfd.DisciplineId);
                result.teacherForDisciplines.Add(new TeacherForDiscipline
                {
                    TeacherForDisciplineId = tfd.TeacherForDisciplineId,
                    Teacher = teacher,
                    Discipline = discipline
                });
            }

            foreach (var lesson in fss.lessons)
            {
                var tefd = result.teacherForDisciplines.FirstOrDefault(
                        tfd => tfd.TeacherForDisciplineId == lesson.TeacherForDisciplineId);
                var cal = result.calendars.FirstOrDefault(c => c.CalendarId == lesson.CalendarId);
                var ring = result.rings.FirstOrDefault(r => r.RingId == lesson.RingId);
                var aud = result.auditoriums.FirstOrDefault(a => a.AuditoriumId == lesson.AuditoriumId);
                result.lessons.Add(new Lesson(lesson.LessonId, tefd, cal, ring, aud, lesson.IsActive == 1));
            }

            foreach (var logEvent in fss.lessonLogEvents)
            {
                var oldLesson = result.lessons.FirstOrDefault(l => l.LessonId == logEvent.OldLessonId);
                var newLesson = result.lessons.FirstOrDefault(l => l.LessonId == logEvent.NewLessonId);
                result.lessonLogEvents.Add(new LessonLogEvent
                {
                    LessonLogEventId = logEvent.LessonLogEventId,
                    Comment = logEvent.Comment,
                    DateTime = logEvent.DateTime,
                    NewLesson = newLesson,
                    OldLesson = oldLesson

                });
            }

            return result;
        }

        public async Task SaveScheduleToFile(string filename = "schedule.txt")
        {
            var fileSchedule = ToFileSchedule();
            string json = JsonConvert.SerializeObject(fileSchedule);

            /*
            var appFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var tempFile = await appFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(tempFile, json);
             */
            await FileExtensions.WriteDataToFileAsync(filename, json);
        }


        public static async Task<Schedule> LoadScheduleFromFile(string filename = "schedule.txt")
        {
            var folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var file = await folder.GetFileAsync(filename);
            //var contents = await Windows.Storage.FileIO.ReadTextAsync(file);
            var contents = await FileExtensions.ReadFileContentsAsync(filename);

            FileSaveSchedule fs = JsonConvert.DeserializeObject<FileSaveSchedule>(contents);
            var schedule = FromFileSaveSchedule(fs);

            return schedule;
        }
         
    }
}
