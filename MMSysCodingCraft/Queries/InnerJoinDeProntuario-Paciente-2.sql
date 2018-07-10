
SELECT pc.Nome, pt.NumAtendimento, LOWER(pt.ProntuarioId) as prontuario_id, LOWER(pt.PacienteGuid) as prontuario_paciente  FROM Prontuario pt
left join Paciente pc on pt.PacienteGuid = pc.PacienteGuid order by pc.Nome;