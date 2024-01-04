export class LoginSetup {
  public static obterLoginForm(){
    return {
      login: () => cy.get('[data-cy=login]'),
      senha: () => cy.get('[data-cy=senha]')
    }
  }
}