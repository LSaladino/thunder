namespace Shared.Modelviews.ManTask
{
    /// <summary>
    /// Objeto utilizado para inserção de um novo cliente
    /// </summary>
    public class NewManTask
    {
        /// <summary>
        /// Descrição da Tarefa
        /// </summary>
        /// <example>Incluir botão na tela</example>
        public string? Description { get; set; }
        /// <summary>
        /// Nome do colaborador responsável
        /// </summary>
        /// <example>Paulo Roberto da silva</example>
        public string? CollaboratorName { get; set; }
        /// <summary>
        /// Comentários sobre detalhes da tarefa
        /// </summary>
        /// <example>Manter o banco sempre atualizado</example>
        public string? Comments { get; set; }
        /// <summary>
        /// Data de inicio da tarefa, sempre um dia depois do cadastro da tarefa
        /// </summary>
        /// <example>2024-06-16</example>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Data de fim da tarefa, sempre 10 dias depois do cadastro da tarefa
        /// </summary>
        /// <example>2024-06-25</example>
        public DateTime EndDate { get; set; }
    }
}
