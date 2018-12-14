drop database Clinic;
create database  ClinicSystem;
use Clinic;

create table user(U_id int primary key,
				  U_name varchar(64),
                  U_type enum ('Admin' ,'Register','Analysis_Doctor','Rays_Doctor','Examination_Doctor'),
                  Pass varchar(64),
                  Email varchar(64) unique,
                  Phone char(11),
                  Address varchar(64),
                  Age int);
insert into user values(1234,'ahmed ali kamel ','Admin','1234','ahmed12@yahoo.com',01234567890,'Assuit',34),
                       (1236,'ahmed ali kamel ','Register','1234','ahmed14@yahoo.com',01234567890,'Sohag',23),
                       (1238,'ahmed ali kamel ','Examination_Doctor','1234','ahmed16@yahoo.com',01234567890,'Minia',24),
                       (1240,'ahmed ali kamel ','Analysis_Doctor','1234','ahmed18@yahoo.com',01234567890,'Luxor',34),
                       (1242,'ahmed ali kamel ','Rays_Doctor','1234','ahmed13@yahoo.com',01234567890,'Cairo',34);


create table patient (P_id int primary key,P_name varchar(64),
					  P_age int,P_address varchar(64),
                      P_phone char(11),
                      P_sex enum('Male','Female'),
                      Marital_Status enum('Engagged','Married','single'),
                      registerDate date);
insert into patient values(100,'ahmed ali',34,'Abu Tig',01234567892,'Male','Married','2017-02-12'),
                          (200,'adel kamel',25,'Luxor',01234567892,'Male','Married','2017-12-12');
                          
create table admittion(A_id int primary key auto_increment  ,
					   A_date date,
                       A_P_id int  ,
                       A_complaint text,
                       A_family_history text,
                       A_presentIllness_history text,
                       A_medical_history text,                       
                       foreign key(A_P_id) references patient(P_id),
                       A_examined bool);
alter table admittion auto_increment=1;
insert into admittion (A_date ,A_P_id,A_complaint, A_family_history,A_presentIllness_history,A_medical_history,A_examined)
	           values('2017-12-10',100,'fever','no family history','high temeperature',' panadol analgesia',true),
                     ('2017-12-16',100,'fever','no family history','high temeperature',' panadol analgesia',true),
	                 ('2017-12-09',200,'fever','no family history','high temeperature',' panadol analgesia',false),
					 ('2017-12-16',200,'fever','no family history','high temeperature',' panadol analgesia',false),
					 ('2017-11-15',100,'fever','no family history','high temeperature',' panadol analgesia',true);

create table examination(E_id int primary key auto_increment,
                         E_A_id int ,
                         E_general_lock text,
						 E_pulse int,
						 E_blood_pressure int,
						 E_temprature double ,
						 E_respiration_rate text,
						 E_head_neck text,
						 E_chest_examine text,         
						 E_cardiac_examine text,
						 E_Abd_inspection text,
                         E_Abd_superficial_palpation text,
                         E_Abd_deep_palpation text,
                         E_Abd_percussion text,
                         E_Abd_ausculation text,
                         E_provisional_diagnosis text,
                         foreign key(E_A_id) references admittion(A_id));
alter table examination auto_increment=1;
 
delimiter *
 CREATE trigger v after insert on examination
 for each row
 begin
 update admittion set A_examined =true ;
 end ;
 *
 delimiter ;

insert into examination values(1,2,'good',120,45,37,'fine','need some rays','good','very good','good','good','good','good','good',100);
create table medicine(
                      M_id int primary key,
                      M_name varchar(64) 
                      );
insert into medicine values(10,'congestal'),
                           (20,'ketofan'),
                           (30,'panadol extra'), 
                           (40,'cometrex');
                          
create table Admission_medicine ( 
                             Adm_id int ,
                             med_id int ,
                             primary key (Adm_id,med_id),
                             foreign key (med_id)references medicine(M_id) ,
                             foreign key(Adm_id) references admittion(A_id));

create table analysis(A_id int primary key ,name varchar(64));
insert into analysis values (100,'Complete_Blood_Picture'),
                            (200,'Coagulation_Profile'),
                            (300,'Elecrolytes_And_Functions'),
                            (400,'Liver_Function_Tests'),
                            (500,'Urine_Analysis'),
                            (600,'Stool_Analysis'),
                            (700,'Alpha_Feto_Protein'),
                            (800,'Ascitic_Fluid');
                                                 
create table Admission_analysis(
                               Adm_id int ,
                               Analysis_id int ,
                               primary key (Adm_id,Analysis_id), 
                               done bool,
                               foreign key (Analysis_id)references analysis(A_id) ,
                               foreign key(Adm_id) references admittion(A_id));
 
 create table rays(R_id int primary key ,name varchar(64));
insert into rays values (100,'Chest X_Ray'),
					    (200,'Abdominal U/S'),
						(300,'MSCT Abdomen');
                               
 create table Admission_rays(
                               Adm_id int ,
                               Ray_id int ,
                               done bool,
                               primary key (Adm_id,Ray_id), 
                               foreign key (Ray_id)references rays(R_id) ,
                               foreign key(Adm_id) references admittion(A_id));
 insert into Admission_rays values(4,100,false);
 insert into Admission_rays values(5,100,false);
 insert into Admission_rays values(2,100,false);
 insert into Admission_rays values(1,100,false);
 insert into Admission_rays values(3,100,false);
 insert into Admission_rays values(2,300,false);
 insert into Admission_rays values(4,200,false);
 
 create table comments (Com_id int  primary key auto_increment, adm int,comment text,foreign key(adm)references admittion(A_id));
 
create table chest(id int ,chest varchar(64),primary key(id,chest),foreign key(id)references admittion(A_id)); 
create table abdominal(id int ,name varchar(100),primary key(id,name),foreign key(id)references admittion(A_id));
create table msct(id int,name varchar(100),primary key(id,name),foreign key(id)references admittion(A_id));

insert into chest(id, chest) values(100,'examine is fine'),(200,'good examine');
insert into abdominal(id,name) values(100,'examine is fine'),(200,'good examine');
insert into msct (id,name) values(100,'examine is fine'),(200,'good examine');
insert into appointment (p_name,appoint) values('ahmed',12),('ali',1),
		      ('hisham',2), ('nour',4),('marawa',5),('shahd',6);






insert into abdominal values(2,'the examine is fine');


insert into msct values('the examine is fine ');
create table blood(Adm_id int,parameters int,hb int, mcv int , mch int,reticulocyte int ,plates int , tlc int, neutrophil int , lymphocyte int ,eosinophile int,foreign key(Adm_id) references admittion(A_id) );
create table profil(parameter int,pt int ,pc int ,inr int ,aptt int);
create table electrolytes(prameters int , na int , k int ,mg int , phosphor int ,ura int , creatinine int);
create table liver(parameter int , total int , direct int , ast int , alt int ,alp int,proteins int , albumin int );

 
 
 create table blood(b_id int , foreign key(b_id) references admittion(A_id),parameters int,hb int, mcv int , mch int,reticulocyte int ,plates int , tlc int, neutrophil int , lymphocyte int ,eosinophile int );

insert into blood (parameters,hb , mcv  , mch ,reticulocyte,plates  , tlc , neutrophil , lymphocyte  ,eosinophile) values (3,6,1,7,9,4,13,2,11,4),(23,6,1,17,9,34,13,2,11,14),(3,16,1,7,9,4,13,2,10,4),(33,46,1,7,9,44,13,2,11,4),(3,6,1,7,9,4,13,2,11,4);

create table profil(pr_id int , foreign key(pr_id) references admittion(A_id),parameter int,pt int ,pc int ,inr int ,aptt int);

insert into profil(parameter ,pt  ,pc ,inr ,aptt) values (1,2,3,4,5),(44,22,12,15,1),(37,32,65,12,63);

create table electrolytes(el_id int , foreign key(el_id) references admittion(A_id),prameters int , na int , k int ,mg int , phosphor int ,ura int , creatinine int);

insert into electrolytes(parameter, na , k ,mg  , phosphor  ,ura  , creatinine)values(1,2,3,4,5,6,7),(43,64,23,25,12,72,33),(37,32,65,12,63,54,24);

create table liver(l_id int , foreign key(l_id) references admittion(A_id),parameter int , total int , direct int , ast int , alt int ,alp int,proteins int , albumin int );

insert into liver(parameter , total  , direct , ast  , alt  ,alp ,proteins  , albumin ) values(3,16,1,7,9,4,13,2),(33,46,1,7,9,44,13,2),(3,6,1,7,9,4,13,2);

create table urine(name varchar(100));

insert into urine values('the examine is fine ');

create table stool(name varchar(100));

insert into stool values('need some rays ');


create table alpha(name varchar(100));

insert into alpha values('the examine is fine ');



insert into chest values('good examin ');




 