// JScript File
// to highlight textbox on validation error

ValidatorCommonOnSubmit = function() 
{                    
    ClearValidatorCallouts();
    var result = SetValidatorCallouts();                                                                                           
    return result;
}

ValidatorValidate = function(val, validationGroup, event) 
{
    val.isvalid = true;
    if ((typeof(val.enabled) == 'undefined' || val.enabled != false) && IsValidationGroupMatch(val, validationGroup)) 
    {
        if (typeof(val.evaluationfunction) == 'function') 
        {
            val.isvalid = val.evaluationfunction(val);
            if (!val.isvalid && Page_InvalidControlToBeFocused == null && typeof(val.focusOnError) == 'string' && val.focusOnError == 't') 
            {
                ValidatorSetFocus(val, event);
            }
    }

}

    ClearValidatorCallouts();
    SetValidatorCallouts(); 
    ValidatorUpdateDisplay(val);
}

SetValidatorCallouts = function()
{
    var i;
    var pageValid = true;                    
    for (i = 0; i < Page_Validators.length; i++) 
    {         
        var inputControl = document.getElementById(Page_Validators[i].controltovalidate);               
        if (!Page_Validators[i].isvalid) 
        {   
            if(pageValid)
                inputControl.focus();
            WebForm_AppendToClassName(inputControl, 'error');
            pageValid = false;                                                     
        }                        
    }                    

  return pageValid;
}

ClearValidatorCallouts = function()
{
    var i;                    
    var invalidConrols = [];
    for (i = 0; i < Page_Validators.length; i++) 
    {         
        var inputControl = document.getElementById(Page_Validators[i].controltovalidate);               
        WebForm_RemoveClassName(inputControl, 'error');                                                  
    }                                        
} 

function WebForm_RemoveClassName(element, className) 
{
    var current = element.className;
    if (current) 
    {
      if (current.substring(current.length - className.length - 1, current.length) == ' ' + className) 
      {
        element.className = current.substring(0, current.length - className.length - 1);
        return;
      }
      
      if (current == className) 
      {
        element.className = "";
        return;
      }
      
      var index = current.indexOf(' ' + className + ' ');
      if (index != -1) 
      {
        /* BUG 1: index + 1 instead of index to include one space */
        element.className = current.substring(0, index + 1) + current.substring(index + className.length + 2, current.length);
        return;
      }
      
      /* BUG 2: className.length + 1 instead of className.length in order that the comparison is true */
      if (current.substring(0, className.length + 1) == className + ' ') 
        element.className = current.substring(className.length + 1, current.length);
    }
}
function WebForm_AppendToClassName(element, className) 
{
    var current = element.className;
    if (current) 
    {
        if (current.charAt(current.length - 1) != ' ') 
        {
            current += ' ';
        }
        current += className;
    }
    else 
    {
        current = className;
    }
    element.className = current;
}

