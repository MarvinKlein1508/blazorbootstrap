﻿namespace BlazorBootstrap;

public partial class DropdownActionButton : BlazorBootstrapComponentBase
{
    #region Fields and Constants

    private ButtonColor color = ButtonColor.None;

    private Size size = Size.None;

    #endregion

    #region Methods

    /// <inheritdoc />
    protected override void BuildClasses()
    {
        this.AddClass(BootstrapClassProvider.Button);
        this.AddClass(BootstrapClassProvider.ButtonColor(Color), Color != ButtonColor.None);
        this.AddClass(BootstrapClassProvider.ButtonSize(Size), Size != Size.None);

        base.BuildClasses();
    }

    protected override void OnInitialized()
    {
        Attributes ??= new Dictionary<string, object>();

        if (!Attributes.TryGetValue("type", out _))
            Attributes.Add("type", "button");

        base.OnInitialized();
    }

    #endregion

    #region Properties, Indexers

    /// <inheritdoc />
    protected override bool ShouldAutoGenerateId => true;

    /// <summary>
    /// Specifies the content to be rendered inside this <see cref="ChildContent" />.
    /// </summary>
    [Parameter]
    public RenderFragment ChildContent { get; set; } = default!;

    /// <summary>
    /// Gets or sets the button color.
    /// </summary>
    [Parameter]
    public ButtonColor Color
    {
        get => color;
        set
        {
            color = value;
            DirtyClasses();
        }
    }

    /// <summary>
    /// Gets or sets the disabled.
    /// </summary>
    [CascadingParameter(Name = "Disabled")]
    public bool Disabled { get; set; }

    /// <summary>
    /// Gets or sets the size of the <see cref="DropdownActionButton" />.
    /// </summary>
    [CascadingParameter(Name = "Size")]
    public Size Size
    {
        get => size;
        set
        {
            size = value;
            DirtyClasses();
        }
    }

    /// <summary>
    /// If defined, indicates that its element can be focused and can participates in sequential keyboard navigation.
    /// </summary>
    [Parameter]
    public int? TabIndex { get; set; }

    #endregion
}
