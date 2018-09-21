using UnityEngine;
using UnityEngine.UI;

public class TweenSlider : UITweener
{
    [Range(0f, 100f)]public float from = 1f;
    public float origin_from = 1f;//记录原始值，用于动画曲线实现平滑效果
    [Range(0f, 100f)]public float to = 1f;
    float round = 0;
    bool mCached = false;
    Image mImage;
    Slider mSlider;

    [System.Obsolete("Use 'value' instead")]
    public float fillAmount { get { return this.value; } set { this.value = value; } }

    void Awake()
    {
        if (awakeFrom && isActive && enabled)
        {
            value = from;
        }
    }

    void Cache()
    {
        mCached = true;

        if (mSlider == null)
            mSlider = GetComponent<Slider>();

        if (mSlider == null && mImage == null)
            mImage = GetComponent<Image>();
    }

    public float value
    {
        get
        {
            if (!mCached) Cache();
            if (mImage != null)
                return mImage.fillAmount + round;
            if (mSlider != null)
                return mSlider.value + round;
            return 0;
        }
        set
        {
            if (!mCached) Cache();
            round = Mathf.Floor(value);
            if (mImage != null)
            {
                from = value;
                mImage.fillAmount = value - round;
                return;
            }

            if (mSlider != null)
            {
                from = value;
                mSlider.value = value - round;
                return;
            }

        }
    }

    /// <summary>
    /// Tween the value.
    /// </summary>

    protected override void OnUpdate(float factor, bool isFinished)
    {
        value = Mathf.Lerp(origin_from, to, factor);
    }

    /// <summary>
    /// Start the tweening operation.
    /// </summary>

    static public TweenSlider Begin(GameObject go, float duration, float value)
    {
        TweenSlider comp = UITweener.Begin<TweenSlider>(go, duration);
        comp.from = comp.value;
        comp.to = value;

        if (duration <= 0f)
        {
            comp.Sample(1f, true);
            comp.enabled = false;
        }
        return comp;
    }

    public override void SetStartToCurrentValue() { from = value; }
    public override void SetEndToCurrentValue() { to = value; }
}
