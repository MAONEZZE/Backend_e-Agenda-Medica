export class CirurgiaSetup{
  public static obterCirurgiaForm(){
    return {
      titulo: cy.get('[data-cy=titulo]'),  
      data: cy.get('[data-cy=data]'),
      horaInicio: cy.get('[data-cy=horaInicio]'),
      horaTermino: cy.get('[data-cy=horaTermino]'),

      selectPaciente: cy.get('[data-cy=selectPaciente]'),
      selectMedico: cy.get('[data-cy=selectMedico]')
    }
  }
}