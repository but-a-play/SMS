SELECT Staff.staff_No, Staff.staff_Name, Staff.staff_IsOnJob, Dept.dept_Name, Job.job_Name
FROM Staff, Dept, Job
WHERE Staff.dept_No = Dept.dept_No AND Staff.job_No = Job.job_No;

INSERT INTO Dept VALUES ('D1', '����һ');
INSERT INTO Dept VALUES ('D2', '���Ŷ�');

INSERT INTO Job VALUES ('J1','�з�����ʦ');
INSERT INTO Job VALUES ('J2','��Ʒ����');
INSERT INTO Job VALUES ('J3','���۾���');

INSERT INTO Staff VALUES ('S1','JACK','J1','D1','��ְ');
INSERT INTO Staff VALUES ('S2','TOM','J1','D2','��ְ');
INSERT INTO Staff VALUES ('S3','JANE','J2','D1','��ְ');
INSERT INTO Staff VALUES ('S4','ROSE','J2','D2','��ְ');
INSERT INTO Staff VALUES ('S5','JAMES','J3','D1','��ְ');
INSERT INTO Staff VALUES ('S6','KOBE','J3','D2','��ְ');

