using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;
using TailwindMerge;

namespace Orbui.Components;

/// <summary>
/// Represents a base class for all components.
/// </summary>
public abstract class BaseComponent : ComponentBase
{
	/// <summary>
	/// Gets or sets an HTML tag of the component.
	/// </summary>
	[Parameter] public string As { get; set; } = "div";

	/// <summary>
	/// Gets or sets CSS class names that will be applied to the component.
	/// </summary>
	[Parameter] public string? Class { get; set; }

	/// <summary>
	/// Gets or sets styles that will be applied to the component.
	/// </summary>
	[Parameter] public string? Style { get; set; }

	/// <summary>
	/// Gets or sets a collection of additional attributes that will be applied to the component.
	/// </summary>
	[Parameter( CaptureUnmatchedValues = true )]
	public IReadOnlyDictionary<string, object>? Attributes { get; set; }

	/// <summary>
	/// Gets or sets the <see cref="TwMerge"/> service.
	/// </summary>
	[Inject] internal TwMerge TwMerge { get; set; } = default!;

	/// <summary>
	/// Gets or sets the associated <see cref="ElementReference"/>.
	/// <para>
	/// May be <see langword="null"/> if accessed before the component is rendered.
	/// </para>
	/// </summary>
	[DisallowNull] public ElementReference? ElementReference { get; protected set; }

	/// <summary>
	/// Gets the passed CSS class string that will be applied to the root element.
	/// </summary>
	private protected virtual string? RootClass => Class;

	/// <summary>
	/// Gets the passed style string that will be applied to the root element.
	/// </summary>
	private protected virtual string? RootStyle => Style;

	/// <summary>
	/// Triggers a re-render of the component.
	/// </summary>
	public void Rerender() => StateHasChanged();
}