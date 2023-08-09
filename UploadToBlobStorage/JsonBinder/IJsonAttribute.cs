using System;
using System.Collections;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;

public class JsonModelBinder : IModelBinder
{
    private readonly JsonOptions _jsonOptions;
    public JsonModelBinder(IOptions<JsonOptions> jsonOptions)
    {
        _jsonOptions = jsonOptions.Value;
    }
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }

        // Check the value sent in
        var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
        if (valueProviderResult != ValueProviderResult.None)
        {
            bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);

            string toSerialize;
            // Attempt to convert the input value
            if (typeof(IEnumerable).IsAssignableFrom(bindingContext.ModelType))
            {
                toSerialize = "[" + string.Join<string>(',', valueProviderResult.Values) + "]";
            }
            else
            {
                toSerialize = valueProviderResult.FirstValue;
            }
            var result = JsonSerializer.Deserialize(toSerialize, bindingContext.ModelType, _jsonOptions.JsonSerializerOptions);
            if (result != null)
            {
                bindingContext.Result = ModelBindingResult.Success(result);
                return Task.CompletedTask;
            }
        }

        return Task.CompletedTask;
    }
}