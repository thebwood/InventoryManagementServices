import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GameSearchFormComponent } from './game-search-form.component';

describe('GameSearchFormComponent', () => {
  let component: GameSearchFormComponent;
  let fixture: ComponentFixture<GameSearchFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GameSearchFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GameSearchFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
