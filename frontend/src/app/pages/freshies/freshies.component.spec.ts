import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FreshiesComponent } from './freshies.component';

describe('FreshiesComponent', () => {
  let component: FreshiesComponent;
  let fixture: ComponentFixture<FreshiesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FreshiesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FreshiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
