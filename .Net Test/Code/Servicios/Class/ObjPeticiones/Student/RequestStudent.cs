using Servicios.Models;
using Servicios.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios.Class.ObjPeticiones
{
    public class RequestStudent
    {
        public RequestStudent(string user_number, string user_password)
        {
            RQ = new RQStudent();
            RQ.user_number = user_number;
            RQ.user_password = user_password;
        }
        private RQStudent rq;
        public RQStudent RQ
        {
            get { return rq; }
            set { rq = value; }
        }
    }

    public class RequestStudentCourse
    {
        public RequestStudentCourse(string user_number, string user_password, int ID_course)
        {
            RQ = new RQStudentCourse();
            RQ.user_number = user_number;
            RQ.user_password = user_password;
            RQ.ID_Course = ID_course;
        }
        private RQStudentCourse rq;
        public RQStudentCourse RQ
        {
            get { return rq; }
            set { rq = value; }
        }
    }

    public class RequestStudentCourses
    {
        public RequestStudentCourses(string user_number, string user_password)
        {
            RQ = new RQStudentCourses();
            RQ.user_number = user_number;
            RQ.user_password = user_password;
        }
        private RQStudentCourses rq;
        public RQStudentCourses RQ
        {
            get { return rq; }
            set { rq = value; }
        }
    }

    public class RequestStudentLessons
    {
        public RequestStudentLessons(string user_number, string user_password, int ID_course)
        {
            RQ = new RQStudentLessons();
            RQ.user_number = user_number;
            RQ.user_password = user_password;
            RQ.ID_course = ID_course;
        }
        private RQStudentLessons rq;
        public RQStudentLessons RQ
        {
            get { return rq; }
            set { rq = value; }
        }
    }

    public class RequestStudentQuestions
    {
        public RequestStudentQuestions(string user_number, string user_password, int ID_lesson)
        {
            RQ = new RQStudentQuestions();
            RQ.user_number = user_number;
            RQ.user_password = user_password;
            RQ.ID_lesson = ID_lesson;
        }
        private RQStudentQuestions rq;
        public RQStudentQuestions RQ
        {
            get { return rq; }
            set { rq = value; }
        }
    }

    public class RequestStudentAnswers
    {
        public RequestStudentAnswers(string user_number, string user_password, int ID_lesson, List<Questions> Questions)
        {
            RQ = new RQStudentAnswer();
            RQ.user_number = user_number;
            RQ.user_password = user_password;
            RQ.Questions = Questions;
            RQ.ID_lesson = ID_lesson;
        }
        private RQStudentAnswer rq;
        public RQStudentAnswer RQ
        {
            get { return rq; }
            set { rq = value; }
        }
    }
   
}