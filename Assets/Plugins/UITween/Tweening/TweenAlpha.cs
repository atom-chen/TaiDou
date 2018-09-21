//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2014 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

/// <summary>
/// Tween the object's alpha. Works with both UI widgets as well as renderers.
/// </summary>

[AddComponentMenu("NGUI/Tween/Tween Alpha")]
public class TweenAlpha : UITweener
{
	[Range(0f, 1f)] public float from = 1f;
	[Range(0f, 1f)] public float to = 1f;

    public bool includeChildren = false;
    public bool autoChildren = false;

	bool mCached = false;
    bool mCacheChild = false;
    CanvasRenderer mCanvasRender;
    CanvasRenderer[] mCanvasRenders;
    [System.Obsolete("Use 'value' instead")]
	public float alpha { get { return this.value; } set { this.value = value; } }

	void Cache ()
	{
		mCached = true;

        if(mCanvasRender == null)
        {
            mCanvasRender = GetComponent<CanvasRenderer>();
        }
	}
    /// <summary>
    /// 暂时不支持动态改变子集
    /// </summary>
    void CacheChildren()
    {
        if (!mCacheChild)
        {
            if (mCanvasRenders == null || autoChildren)
            {
                mCanvasRenders = GetComponentsInChildren<CanvasRenderer>();
            }
            mCacheChild = true;
        }
    }
	/// <summary>
	/// Tween's current value.
	/// </summary>

	public float value
	{
		get
		{
			if (!mCached) Cache();

			return (mCanvasRender != null) ? mCanvasRender.GetAlpha() : 1f;
		}
		set
		{
			if (!mCached) Cache();

            if(mCanvasRender!=null)
            {
                mCanvasRender.SetAlpha(value);
            }

            if (includeChildren)
            {
                CacheChildren();
                foreach (CanvasRenderer cRender in mCanvasRenders)
                {
                    if (cRender != null)
                    {
                        cRender.SetAlpha(value);
                    }
                }
            }
		}
	}
    void Awake()
    {
        if (awakeFrom && isActive && enabled)
        {
            value = from;
        }
    }
    /// <summary>
    /// Tween the value.
    /// </summary>

    protected override void OnUpdate (float factor, bool isFinished) { value = Mathf.Lerp(from, to, factor); }

	/// <summary>
	/// Start the tweening operation.
	/// </summary>

	static public TweenAlpha Begin (GameObject go, float duration, float alpha)
	{
		TweenAlpha comp = UITweener.Begin<TweenAlpha>(go, duration);
		comp.from = comp.value;
		comp.to = alpha;

		if (duration <= 0f)
		{
			comp.Sample(1f, true);
			comp.enabled = false;
		}
		return comp;
	}

	public override void SetStartToCurrentValue () { from = value; }
	public override void SetEndToCurrentValue () { to = value; }
}
