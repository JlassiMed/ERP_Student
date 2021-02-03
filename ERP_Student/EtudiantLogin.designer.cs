﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERP_Student
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ERP_Teacher")]
	public partial class EtudiantLoginDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertetudiant(etudiant instance);
    partial void Updateetudiant(etudiant instance);
    partial void Deleteetudiant(etudiant instance);
    #endregion
		
		public EtudiantLoginDataContext() : 
				base(global::ERP_Student.Properties.Settings.Default.ERP_TeacherConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public EtudiantLoginDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public EtudiantLoginDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public EtudiantLoginDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public EtudiantLoginDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<etudiant> etudiants
		{
			get
			{
				return this.GetTable<etudiant>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.etudiant")]
	public partial class etudiant : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _cin;
		
		private string _nom;
		
		private string _prenom;
		
		private string _mots_de_passe;
		
		private System.Data.Linq.Binary _code_a_bar;
		
		private string _mail;
		
		private System.Data.Linq.Binary _photo;
		
		private string _id_classe;
		
		private System.Nullable<int> _NiveauEtud;
		
		private System.Nullable<int> _Année;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OncinChanging(string value);
    partial void OncinChanged();
    partial void OnnomChanging(string value);
    partial void OnnomChanged();
    partial void OnprenomChanging(string value);
    partial void OnprenomChanged();
    partial void Onmots_de_passeChanging(string value);
    partial void Onmots_de_passeChanged();
    partial void Oncode_a_barChanging(System.Data.Linq.Binary value);
    partial void Oncode_a_barChanged();
    partial void OnmailChanging(string value);
    partial void OnmailChanged();
    partial void OnphotoChanging(System.Data.Linq.Binary value);
    partial void OnphotoChanged();
    partial void Onid_classeChanging(string value);
    partial void Onid_classeChanged();
    partial void OnNiveauEtudChanging(System.Nullable<int> value);
    partial void OnNiveauEtudChanged();
    partial void OnAnnéeChanging(System.Nullable<int> value);
    partial void OnAnnéeChanged();
    #endregion
		
		public etudiant()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cin", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string cin
		{
			get
			{
				return this._cin;
			}
			set
			{
				if ((this._cin != value))
				{
					this.OncinChanging(value);
					this.SendPropertyChanging();
					this._cin = value;
					this.SendPropertyChanged("cin");
					this.OncinChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nom", DbType="VarChar(50)")]
		public string nom
		{
			get
			{
				return this._nom;
			}
			set
			{
				if ((this._nom != value))
				{
					this.OnnomChanging(value);
					this.SendPropertyChanging();
					this._nom = value;
					this.SendPropertyChanged("nom");
					this.OnnomChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_prenom", DbType="VarChar(50)")]
		public string prenom
		{
			get
			{
				return this._prenom;
			}
			set
			{
				if ((this._prenom != value))
				{
					this.OnprenomChanging(value);
					this.SendPropertyChanging();
					this._prenom = value;
					this.SendPropertyChanged("prenom");
					this.OnprenomChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_mots_de_passe", DbType="VarChar(50)")]
		public string mots_de_passe
		{
			get
			{
				return this._mots_de_passe;
			}
			set
			{
				if ((this._mots_de_passe != value))
				{
					this.Onmots_de_passeChanging(value);
					this.SendPropertyChanging();
					this._mots_de_passe = value;
					this.SendPropertyChanged("mots_de_passe");
					this.Onmots_de_passeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_code_a_bar", DbType="Image", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary code_a_bar
		{
			get
			{
				return this._code_a_bar;
			}
			set
			{
				if ((this._code_a_bar != value))
				{
					this.Oncode_a_barChanging(value);
					this.SendPropertyChanging();
					this._code_a_bar = value;
					this.SendPropertyChanged("code_a_bar");
					this.Oncode_a_barChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_mail", DbType="VarChar(50)")]
		public string mail
		{
			get
			{
				return this._mail;
			}
			set
			{
				if ((this._mail != value))
				{
					this.OnmailChanging(value);
					this.SendPropertyChanging();
					this._mail = value;
					this.SendPropertyChanged("mail");
					this.OnmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_photo", DbType="Image", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary photo
		{
			get
			{
				return this._photo;
			}
			set
			{
				if ((this._photo != value))
				{
					this.OnphotoChanging(value);
					this.SendPropertyChanging();
					this._photo = value;
					this.SendPropertyChanged("photo");
					this.OnphotoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_classe", DbType="VarChar(50)")]
		public string id_classe
		{
			get
			{
				return this._id_classe;
			}
			set
			{
				if ((this._id_classe != value))
				{
					this.Onid_classeChanging(value);
					this.SendPropertyChanging();
					this._id_classe = value;
					this.SendPropertyChanged("id_classe");
					this.Onid_classeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NiveauEtud", DbType="Int")]
		public System.Nullable<int> NiveauEtud
		{
			get
			{
				return this._NiveauEtud;
			}
			set
			{
				if ((this._NiveauEtud != value))
				{
					this.OnNiveauEtudChanging(value);
					this.SendPropertyChanging();
					this._NiveauEtud = value;
					this.SendPropertyChanged("NiveauEtud");
					this.OnNiveauEtudChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Année", DbType="Int")]
		public System.Nullable<int> Année
		{
			get
			{
				return this._Année;
			}
			set
			{
				if ((this._Année != value))
				{
					this.OnAnnéeChanging(value);
					this.SendPropertyChanging();
					this._Année = value;
					this.SendPropertyChanged("Année");
					this.OnAnnéeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
