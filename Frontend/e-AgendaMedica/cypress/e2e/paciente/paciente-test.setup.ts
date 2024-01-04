export class PacienteSetup{
  public static obterPacienteForm() {
    return {
      nome: () => cy.get('[data-cy=nome]'),
      cpf: () => cy.get('[data-cy=cpf]'),
      email: () => cy.get('[data-cy=email]'),
      telefone: () => cy.get('[data-cy=telefone]'),
      dataN: () => cy.get('[data-cy=data]')
    }
  }
}