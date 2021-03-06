package com.odysseyserver.usermanagement;

import java.io.FileWriter;
import java.io.IOException;

import org.jdom2.Document;
import org.json.simple.JSONArray;
import org.json.simple.JSONObject;

public class GestorJSONUsuario {

	@SuppressWarnings("unchecked")
	public static JSONObject generarUsuarioJSON(Document doc) {
		JSONObject usuario = new JSONObject();
		usuario.put("username", doc.getRootElement().getChildText("NombreUsuario"));
		usuario.put("contraseņa", doc.getRootElement().getChildText("Contrasena"));
		usuario.put("nombre", doc.getRootElement().getChildText("NombreApellidos"));
		usuario.put("edad", doc.getRootElement().getChildText("Edad"));
		usuario.put("generos", doc.getRootElement().getChildText("Generos"));
		usuario.put("amigos", new JSONArray());
		usuario.put("notificacion", new JSONArray());
		return usuario;
	}

	public static void reescribirXML(JSONArray jsonList) {
		try {
			FileWriter jsonWriter = new FileWriter("data\\jsondata\\jsonUsuarios.json");
			jsonWriter.write(jsonList.toJSONString());
			jsonWriter.flush();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

}
