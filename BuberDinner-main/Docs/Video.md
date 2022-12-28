# Video

- [Video](#video)
  - [Data Annotations](#data-annotations)
    - [Without `ApiController` Attribute](#without-apicontroller-attribute)
      - [Checking Model State Manually](#checking-model-state-manually)
    - [With `ApiController` Attribute](#with-apicontroller-attribute)
      - [Automatically Checking Model State](#automatically-checking-model-state)
    - [Custom Validation Attribute](#custom-validation-attribute)
  - [`FluentValidation` Library](#fluentvalidation-library)
    - [Without `FluentValidation.AspNetCore` Library](#without-fluentvalidationaspnetcore-library)
      - [Manually Registering Validator](#manually-registering-validator)
      - [Manually Invoking `Validate` and returning a `ValidationProblem`](#manually-invoking-validate-and-returning-a-validationproblem)
    - [With `FluentValidation.AspNetCore` Library](#with-fluentvalidationaspnetcore-library)
      - [Registering All Validators](#registering-all-validators)
      - [Using `AddFluentValidation` To Auto Validate Models](#using-addfluentvalidation-to-auto-validate-models)
    - [Built-in Validators](#built-in-validators)
    - [Custom Validators](#custom-validators)
      - [Predicate](#predicate)
        - [Place Holders](#place-holders)
      - [Message Place Holders](#message-place-holders)
        - [Adding Custom Place Holders](#adding-custom-place-holders)
      - [Custom Validator](#custom-validator)

## Data Annotations

### Without `ApiController` Attribute

#### Checking Model State Manually

### With `ApiController` Attribute

#### Automatically Checking Model State

### Custom Validation Attribute

## `FluentValidation` Library

### Without `FluentValidation.AspNetCore` Library

#### Manually Registering Validator

#### Manually Invoking `Validate` and returning a `ValidationProblem`

### With `FluentValidation.AspNetCore` Library

#### Registering All Validators

#### Using `AddFluentValidation` To Auto Validate Models

### Built-in Validators

- `NotNull`
- `NotEmpty`
- `NotEqual`
- `Equal`
- `Length`
- `MaxLength`
- `MinLength`
- `LessThan`
- `LessThanOrEqual`
- `GreaterThan`
- `GreaterThanOrEqual`
- Predicate
- Regex
- Email
- Credit Card
- Enum
- Enum Name
- Empty
- `ExclusiveBetween`
- `InclusiveBetween`
- `ScalePrecision`

### Custom Validators

#### Predicate

```csharp
public static class MyCustomValidators
{
    public static IRuleBuilderOptions<T, IList<TElement>> ListMustContainFewerThan<T, TElement>(this IRuleBuilder<T, IList<TElement>> ruleBuilder, int num)
    {
        return ruleBuilder.Must(list => list.Count < num).WithMessage("The list contains too many items");
    }
}
```

##### Place Holders

```csharp
{PropertyName}
{PropertyValue}
```

#### Message Place Holders

##### Adding Custom Place Holders

```csharp
public static IRuleBuilderOptions<T, IList<TElement>> ListMustContainFewerThan<T, TElement>(this IRuleBuilder<T, IList<TElement>> ruleBuilder, int num) {

  return ruleBuilder.Must((rootObject, list, context) => {
    context.MessageFormatter.AppendArgument("MaxElements", num);
    return list.Count < num;
  })
  .WithMessage("{PropertyName} must contain fewer than {MaxElements} items.");
}
```

#### Custom Validator

```csharp
public class PersonValidator : AbstractValidator<Person> {
  public PersonValidator() {
   RuleFor(x => x.Pets).Custom((list, context) => {
     if(list.Count > 10) {
       context.AddFailure("The list must contain 10 items or fewer");
     }
   });
  }
}
```