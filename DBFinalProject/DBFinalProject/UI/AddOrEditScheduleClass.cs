using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using DBProjectBackend.BL;

namespace DBFinalProject.UI
{
	public partial class AddOrEditScheduleClass : DBFinalProject.UI.AdminDashboard
	{
		public AddOrEditScheduleClass()
		{
			InitializeComponent();
            bindcmbTimeSlot();
            bindcmbRoom();
            bindcmbFacultyCourse();
            bindcmbEditScheduledClass();
        }

        private void bindcmbEditScheduledClass()
        {
            DBProjectBackend.BL.ScheduledClass scheduledClass = new DBProjectBackend.BL.ScheduledClass();
            List<object> scheduledClassNames = scheduledClass.GetScheduledClassNames();
            cmbEdit.DataSource = scheduledClassNames;
            cmbEdit.SelectedIndex = -1;
        }

        private void bindcmbFacultyCourse()
        {
            DBProjectBackend.BL.FacultyCourses facultyCourse = new DBProjectBackend.BL.FacultyCourses();
            List<object> assignmentnames = facultyCourse.GetFacultyCoursesAssignment();
            cmbFacultyCourse.DataSource = assignmentnames;
            cmbFacultyCourse.SelectedIndex = -1;
        }

        private void bindcmbRoom()
        {
            DBProjectBackend.BL.Room room = new DBProjectBackend.BL.Room();
            List<object> roomnames = room.GetRoomNames();
            cmbRoom.DataSource = roomnames;
            cmbRoom.SelectedIndex = -1;
        }

        private void bindcmbTimeSlot()
        {
            DBProjectBackend.BL.Timetable t = new DBProjectBackend.BL.Timetable();
            List<object> timetableSlots = t.GetTimetableSlots();
            cmbTimeSlot.DataSource = timetableSlots;
            cmbTimeSlot.SelectedIndex = -1;
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            try
            {
                
                string room = cmbRoom.Text.ToString().Trim();
                string facultycourse = cmbFacultyCourse.Text.ToString().Trim();
                string slot = cmbTimeSlot.Text.ToString().Trim();

                //Fetch RoomID because we have to store ID not Dept Name
                Room rl = new Room();
                int roomID = rl.GetRoomID(room);

                //Fetch SlotID because we have to store ID not Details 
                DBProjectBackend.BL.Timetable t = new DBProjectBackend.BL.Timetable();
                int? timeTableID = t.GetTimetableID(slot);

                //Fetch FacultyCourseID because we have to store ID
                FacultyCourses fc = new FacultyCourses();
                int? facultyCourseID = fc.GetFacultyCourseID(facultycourse);


                DBProjectBackend.BL.ScheduledClass scheduledclass = new DBProjectBackend.BL.ScheduledClass(roomID, facultyCourseID, timeTableID);
                bool flag = scheduledclass.AddScheduledClass(scheduledclass);
                if (flag)
                {
                    MessageBox.Show("Class Scheduled Successfully");
                }
                else
                {
                    MessageBox.Show("Class Scheduling Unsuccessful");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            try
            {

                string room = cmbRoom.Text.ToString().Trim();
                string facultycourse = cmbFacultyCourse.Text.ToString().Trim();
                string slot = cmbTimeSlot.Text.ToString().Trim();
                int edit = int.Parse(cmbEdit.Text.ToString().Trim());

                //Fetch RoomID because we have to store ID not Dept Name
                Room rl = new Room();
                int roomID = rl.GetRoomID(room);

                //Fetch SlotID because we have to store ID not Details 
                DBProjectBackend.BL.Timetable t = new DBProjectBackend.BL.Timetable();
                int? timeTableID = t.GetTimetableID(slot);

                //Fetch FacultyCourseID because we have to store ID
                FacultyCourses fc = new FacultyCourses();
                int? facultyCourseID = fc.GetFacultyCourseID(facultycourse);

                //Fetch ScheduledClassID because we have to store ID
                DBProjectBackend.BL.ScheduledClass scheduledClass = new DBProjectBackend.BL.ScheduledClass();
                int scheduledClassID = scheduledClass.GetScheduledClassID(edit);


                DBProjectBackend.BL.ScheduledClass scheduledclass = new DBProjectBackend.BL.ScheduledClass(scheduledClassID, roomID, facultyCourseID, timeTableID);
                bool flag = scheduledclass.UpdateScheduledClass(scheduledclass);
                if (flag)
                {
                    MessageBox.Show("Class Schedule Updated Successfully");
                }
                else
                {
                    MessageBox.Show("Class Schedule Updation Unsuccessful");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
