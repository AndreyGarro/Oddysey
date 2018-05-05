package com.odysseyserver.usermanagement;

public class Usuario {
	private String username;
	private String contrase�a;
	private String nombre;
	private String apellidos;
	private String edad;
	private String generosM;
	private String amigos;
	private String notificacion;
	
	public Usuario() {
		
	}
	public Usuario(String username, String contrase�a, String nombre, String apellidos, String edad, String generosM,
			String amigos, String notificacion) {
		super();
		this.username = username;
		this.contrase�a = contrase�a;
		this.nombre = nombre;
		this.apellidos = apellidos;
		this.edad = edad;
		this.generosM = generosM;
		this.amigos = amigos;
		this.notificacion = notificacion;
	}
	public String getUsername() {
		return username;
	}
	public void setUsername(String username) {
		this.username = username;
	}
	public String getContrase�a() {
		return contrase�a;
	}
	public void setContrase�a(String contrase�a) {
		this.contrase�a = contrase�a;
	}
	public String getNombre() {
		return nombre;
	}
	public void setNombre(String nombre) {
		this.nombre = nombre;
	}
	public String getApellidos() {
		return apellidos;
	}
	public void setApellidos(String apellidos) {
		this.apellidos = apellidos;
	}
	public String getEdad() {
		return edad;
	}
	public void setEdad(String edad) {
		this.edad = edad;
	}
	public String getGenerosM() {
		return generosM;
	}
	public void setGenerosM(String generosM) {
		this.generosM = generosM;
	}
	public String getAmigos() {
		return amigos;
	}
	public void setAmigos(String amigos) {
		this.amigos = amigos;
	}
	public String getNotificacion() {
		return notificacion;
	}
	public void setNotificacion(String notificacion) {
		this.notificacion = notificacion;
	}
	
	
}
